using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Collections;

namespace Q205071 {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);
            // TODO: This line of code loads data into the 'nwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.nwindDataSet.Products);
        }

        private void OnGridControlEmbeddedNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "update") {
                if (gridControl1.FocusedView == gridView1) nwindDataSet.Categories.AcceptChanges(); 
                else if (gridControl1.FocusedView.ParentView == gridView1) nwindDataSet.Products.AcceptChanges();
            }
        }

        private bool newRow = false;
        private void OnGridViewInitNewRow(object sender, InitNewRowEventArgs e) {
            newRow = true;
        }

        private void OnGridViewRowCountChanged(object sender, EventArgs e) {
            if (!newRow) return;
            newRow = false;
            BeginInvoke(new ExpandNewRowDelegate(ExpandNewRow), new object[] { sender });
        }

        private void ExpandNewRow(GridView view) {
            view.MasterRowExpanded += new CustomMasterRowEventHandler(OnGridViewMasterRowExpanded);
            view.SetMasterRowExpanded(view.GetRowHandle(((IList)view.DataSource).Count - 1), true);
        }

        private delegate void ExpandNewRowDelegate(GridView view);

        private void OnGridViewMasterRowExpanded(object sender, CustomMasterRowEventArgs e) {
            GridView view = (GridView)sender;
            view.MasterRowExpanded -= OnGridViewMasterRowExpanded;
            GridView childView = (GridView)view.GetDetailView(e.RowHandle, e.RelationIndex);
            childView.AddNewRow();
            BeginInvoke(new FocusNewRowDelegate(FocusNewRow), new object[] { childView });
        }

        private void FocusNewRow(GridView childView) {
            gridControl1.FocusedView = childView;
            childView.ShowEditor();
        }

        private delegate void FocusNewRowDelegate(GridView view);
    }
}
