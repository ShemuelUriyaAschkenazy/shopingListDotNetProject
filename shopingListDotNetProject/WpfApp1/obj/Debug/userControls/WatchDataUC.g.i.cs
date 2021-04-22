﻿#pragma checksum "..\..\..\userControls\WatchDataUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1AF6B8D38342D0DDFB19E744454C47D11D3953B4F88A764C1B8FD47A73F4D964"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PL.userControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PL.userControls {
    
    
    /// <summary>
    /// WatchDataUC
    /// </summary>
    public partial class WatchDataUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid BuyingsDataGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn ProductColumn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn StoreColumn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn dateColumn;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn UserColumn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rightGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\userControls\WatchDataUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PL;component/usercontrols/watchdatauc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\userControls\WatchDataUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BuyingsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 15 "..\..\..\userControls\WatchDataUC.xaml"
            this.BuyingsDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.BuyingsDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProductColumn = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 3:
            this.StoreColumn = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 4:
            this.dateColumn = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 5:
            this.UserColumn = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 6:
            this.rightGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

