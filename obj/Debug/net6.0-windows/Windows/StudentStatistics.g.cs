﻿#pragma checksum "..\..\..\..\Windows\StudentStatistics.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FD8018B611FF3C7C00E92C538CF86E6CCFB4FB7B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ExamsSystem.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ExamsSystem.Windows {
    
    
    /// <summary>
    /// StudentStatistics
    /// </summary>
    public partial class StudentStatistics : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Windows\StudentStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Windows\StudentStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid STDataGrid;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Windows\StudentStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid STDDataGrid;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Windows\StudentStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SADataGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Windows\StudentStatistics.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_ewa;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ExamsSystem;component/windows/studentstatistics.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\StudentStatistics.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Windows\StudentStatistics.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.STDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\..\Windows\StudentStatistics.xaml"
            this.STDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.STDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 20 "..\..\..\..\Windows\StudentStatistics.xaml"
            this.STDataGrid.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.STDataGrid_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.STDDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\..\..\Windows\StudentStatistics.xaml"
            this.STDDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.STDDataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SADataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 23 "..\..\..\..\Windows\StudentStatistics.xaml"
            this.SADataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SADataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lbl_ewa = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

