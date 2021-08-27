<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128625636/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1436)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Q205071/Form1.cs) (VB: [Form1.vb](./VB/Q205071/Form1.vb))
* [Program.cs](./CS/Q205071/Program.cs) (VB: [Program.vb](./VB/Q205071/Program.vb))
<!-- default file list end -->
# How to automatically expand the detail view when new master row is added


<p>To accomplish this task, enable the GridView.OptionsDetail.AllowExpandEmptyDetails option for the master grid view and use the GridView.SetMasterRowExpanded method to expand an appropriate master row within the GridView.RowCountChanged event handler. Please note, this scenario won't work with sorted or filtered data source.</p>

<br/>


