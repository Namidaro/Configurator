﻿#pragma checksum "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31934DEBBF60DFDA2FCF944E3F9F81516F2C7261"
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
using UniconGS.Converters;


namespace UniconGS.UI.HeatingSchedule {
    
    
    /// <summary>
    /// HeatingSchedule
    /// </summary>
    public partial class HeatingSchedule : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiImport;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiExport;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PART_TURNOFF;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox uiTurnOffDay;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox uiTurnOffMonth;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PART_TURNON;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox uiTunrOnDay;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox uiTurnOnMonth;
        
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
            System.Uri resourceLocater = new System.Uri("/PicGSConfig;component/ui/heatingschedule/heatingschedule.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
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
            this.uiImport = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
            this.uiImport.Click += new System.Windows.RoutedEventHandler(this.uiImport_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.uiExport = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\UI\HeatingSchedule\HeatingSchedule.xaml"
            this.uiExport.Click += new System.Windows.RoutedEventHandler(this.uiExport_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PART_TURNOFF = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.uiTurnOffDay = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.uiTurnOffMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.PART_TURNON = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.uiTunrOnDay = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.uiTurnOnMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

