Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections

Namespace Q205071

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
            categoriesTableAdapter.Fill(nwindDataSet.Categories)
            ' TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            productsTableAdapter.Fill(nwindDataSet.Products)
        End Sub

        Private Sub OnGridControlEmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As NavigatorButtonClickEventArgs)
            If e.Button.Tag IsNot Nothing AndAlso Equals(e.Button.Tag.ToString(), "update") Then
                If gridControl1.FocusedView Is gridView1 Then
                    nwindDataSet.Categories.AcceptChanges()
                ElseIf gridControl1.FocusedView.ParentView Is gridView1 Then
                    nwindDataSet.Products.AcceptChanges()
                End If
            End If
        End Sub

        Private newRow As Boolean = False

        Private Sub OnGridViewInitNewRow(ByVal sender As Object, ByVal e As InitNewRowEventArgs)
            newRow = True
        End Sub

        Private Sub OnGridViewRowCountChanged(ByVal sender As Object, ByVal e As EventArgs)
            If Not newRow Then Return
            newRow = False
            BeginInvoke(New ExpandNewRowDelegate(AddressOf ExpandNewRow), New Object() {sender})
        End Sub

        Private Sub ExpandNewRow(ByVal view As GridView)
            AddHandler view.MasterRowExpanded, New CustomMasterRowEventHandler(AddressOf OnGridViewMasterRowExpanded)
            view.SetMasterRowExpanded(view.GetRowHandle(CType(view.DataSource, IList).Count - 1), True)
        End Sub

        Private Delegate Sub ExpandNewRowDelegate(ByVal view As GridView)

        Private Sub OnGridViewMasterRowExpanded(ByVal sender As Object, ByVal e As CustomMasterRowEventArgs)
            Dim view As GridView = CType(sender, GridView)
            RemoveHandler view.MasterRowExpanded, AddressOf OnGridViewMasterRowExpanded
            Dim childView As GridView = CType(view.GetDetailView(e.RowHandle, e.RelationIndex), GridView)
            childView.AddNewRow()
            BeginInvoke(New FocusNewRowDelegate(AddressOf FocusNewRow), New Object() {childView})
        End Sub

        Private Sub FocusNewRow(ByVal childView As GridView)
            gridControl1.FocusedView = childView
            childView.ShowEditor()
        End Sub

        Private Delegate Sub FocusNewRowDelegate(ByVal view As GridView)
    End Class
End Namespace
