﻿#pragma checksum "..\..\..\..\UI\Settings\ControllerSettings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C69E10B7BFA295701F5A7F7EB70674B5218529EE"
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


namespace UniconGS.UI.Settings {
    
    
    /// <summary>
    /// ControllerSettings
    /// </summary>
    public partial class ControllerSettings : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiOpenSettings;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiSaveSettings;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiReadAll;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiPLCReset;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiSignature;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiWriteAll;
        
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
            System.Uri resourceLocater = new System.Uri("/PicGSConfig;component/ui/settings/controllersettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
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
            this.uiOpenSettings = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiOpenSettings.Click += new System.Windows.RoutedEventHandler(this.uiOpenSettings_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.uiSaveSettings = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiSaveSettings.Click += new System.Windows.RoutedEventHandler(this.uiSaveSettings_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uiReadAll = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiReadAll.Click += new System.Windows.RoutedEventHandler(this.uiReadAll_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.uiPLCReset = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiPLCReset.Click += new System.Windows.RoutedEventHandler(this.uiPLCReset_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.uiSignature = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiSignature.Click += new System.Windows.RoutedEventHandler(this.uiSignature_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.uiWriteAll = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\UI\Settings\ControllerSettings.xaml"
            this.uiWriteAll.Click += new System.Windows.RoutedEventHandler(this.uiWriteAll_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

