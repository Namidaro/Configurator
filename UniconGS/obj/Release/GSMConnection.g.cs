﻿#pragma checksum "..\..\GSMConnection.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "617167AC7C76F3B780B5802B135841F9ACEBA65C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using UniconGS;


namespace UniconGS {
    
    
    /// <summary>
    /// GSMConnection
    /// </summary>
    public partial class GSMConnection : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel uiGSMConnectSettings;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiPortNumberGSM;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiiPTex;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiReadTimeout;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiWriteTimeout;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiRetries;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uiWaitUntilRetry;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiApply;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\GSMConnection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiSettingsCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/PicGSConfig;component/gsmconnection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GSMConnection.xaml"
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
            this.uiGSMConnectSettings = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.uiPortNumberGSM = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.uiiPTex = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.uiReadTimeout = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.uiWriteTimeout = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.uiRetries = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.uiWaitUntilRetry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.uiApply = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.uiSettingsCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

