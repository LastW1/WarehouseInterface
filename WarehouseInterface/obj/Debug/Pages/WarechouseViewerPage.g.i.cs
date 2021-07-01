﻿#pragma checksum "..\..\..\Pages\WarechouseViewerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0CAC65592B8D89E167A0AA378D6BB44E028FD7F73C458DDAA81181A6788DA477"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WarehouseInterface.Pages;


namespace WarehouseInterface.Pages {
    
    
    /// <summary>
    /// WarechouseViewerPage
    /// </summary>
    public partial class WarechouseViewerPage : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 51 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CategoryTextBox;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTextBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllertButton;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TestDataGrid;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HistoryButton;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZamowienieButton;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SupplyButton;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Pages\WarechouseViewerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReturnButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WarehouseInterface;component/pages/warechouseviewerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\WarechouseViewerPage.xaml"
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
            this.CategoryTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.CategoryTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.CategoryTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 52 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.NameTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AllertButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.AllertButton.Click += new System.Windows.RoutedEventHandler(this.AllertButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TestDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 134 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.HistoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 135 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.HistoryButton.Click += new System.Windows.RoutedEventHandler(this.HistoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ZamowienieButton = ((System.Windows.Controls.Button)(target));
            
            #line 137 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.ZamowienieButton.Click += new System.Windows.RoutedEventHandler(this.ZamowienieButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SupplyButton = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.SupplyButton.Click += new System.Windows.RoutedEventHandler(this.SupplyButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ReturnButton = ((System.Windows.Controls.Button)(target));
            
            #line 139 "..\..\..\Pages\WarechouseViewerPage.xaml"
            this.ReturnButton.Click += new System.Windows.RoutedEventHandler(this.ReturnButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 117 "..\..\..\Pages\WarechouseViewerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Details_Click);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 125 "..\..\..\Pages\WarechouseViewerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Edit_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
