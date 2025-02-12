<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128625636/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1436)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Automatically expand a new master row

![WinForms Data Grid - Automatically expand the detail view when adding a master row](https://raw.githubusercontent.com/DevExpress-Examples/how-to-automatically-expand-the-detail-view-when-new-master-row-is-added-e1436/13.1.4%2B/media/winforms-grid-master-detail-aad-row.gif)

* Enable the [GridView.OptionsDetail.AllowExpandEmptyDetails](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridOptionsDetail.AllowExpandEmptyDetails) option for the master grid view
* Handle the [GridView.RowCountChanged](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Base.BaseView.RowCountChanged) event to call the [GridView.SetMasterRowExpanded](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.SetMasterRowExpanded.overloads) method to expand a master row.

> **Note**
>
> This example does not work with sorted or filtered data sources.


## Files to Review

* [Form1.cs](./CS/Q205071/Form1.cs) (VB: [Form1.vb](./VB/Q205071/Form1.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-auto-expand-new-master-row&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-auto-expand-new-master-row&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
