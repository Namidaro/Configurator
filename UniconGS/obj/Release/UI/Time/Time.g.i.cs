﻿#pragma checksum "..\..\..\..\UI\Time\Time.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5771D39B699A31447B780140A18531862C334D78"
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


namespace UniconGS.UI.Time {
    
    
    /// <summary>
    /// Time
    /// </summary>
    public partial class Time : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label uiLocalTime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label uiLocalDate;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label uiRealTime;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label uiRealDate;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiChangeTime;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\UI\Time\Time.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiSystemTime;
        
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
            System.Uri resourceLocater = new System.Uri("/PicGSConfig;component/ui/time/time.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Time\Time.xaml"
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
            this.uiLocalTime = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.uiLocalDate = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.uiRealTime = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.uiRealDate = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.uiChangeTime = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\UI\Time\Time.xaml"
            this.uiChangeTime.Click += new System.Windows.RoutedEventHandler(this.uiChangeTime_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.uiSystemTime = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\UI\Time\Time.xaml"
            this.uiSystemTime.Click += new System.Windows.RoutedEventHandler(this.uiSystemTime_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

