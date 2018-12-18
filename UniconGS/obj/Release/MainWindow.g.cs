﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D89106D2CC2902A766D9EF074F056AE9D759975"
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
using UniconGS.UI;
using UniconGS.UI.Channels;
using UniconGS.UI.Configuration;
using UniconGS.UI.DiscretModules;
using UniconGS.UI.GPRS;
using UniconGS.UI.HeatingSchedule;
using UniconGS.UI.Journal;
using UniconGS.UI.MRNetworking;
using UniconGS.UI.Picon2;
using UniconGS.UI.Picon2.ModuleRequests;
using UniconGS.UI.Schedule;
using UniconGS.UI.Settings;
using UniconGS.UI.Time;


namespace UniconGS {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiDeviceSelection;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiConnect;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiReconnect;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiAutonomous;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiDisconnect;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiExit;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiAbout;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem uiUsersGyde;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border PART_MAINBODY;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl uiMainControl;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border uiHider;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiConnectBtn;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiReconnectBtn;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiAutonomousBtn;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiDisconnectBtn;
        
        #line default
        #line hidden
        
        
        #line 187 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button uiGSMConnection;
        
        #line default
        #line hidden
        
        
        #line 251 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem DiagnosticTab;
        
        #line default
        #line hidden
        
        
        #line 271 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Time.Time uiTime;
        
        #line default
        #line hidden
        
        
        #line 298 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer uiScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 306 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.PiconGSDiagnostics uiPiconDiagnostics;
        
        #line default
        #line hidden
        
        
        #line 311 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer uiScrollViewerPicon2;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2Diagnostic uiPicon2Diagnostics;
        
        #line default
        #line hidden
        
        
        #line 327 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2DiagnosticsErrors uiPicon2DiagnosticsErrors;
        
        #line default
        #line hidden
        
        
        #line 338 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer uiScrollPicon2ModuleErrors;
        
        #line default
        #line hidden
        
        
        #line 348 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2ModuleErrors uiPicon2ModuleErrors;
        
        #line default
        #line hidden
        
        
        #line 355 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.DiagnosticsErrors uiDiagnosticsErrors;
        
        #line default
        #line hidden
        
        
        #line 365 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer uiScroll;
        
        #line default
        #line hidden
        
        
        #line 375 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Runo3Diagnostics uiRuno3Diagnostics;
        
        #line default
        #line hidden
        
        
        #line 384 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Settings.ControllerSettings uiSettings;
        
        #line default
        #line hidden
        
        
        #line 396 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Journal.SystemJournal uiSystemJournal;
        
        #line default
        #line hidden
        
        
        #line 404 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.SignalGSMLevel uiSignalGSMLevel;
        
        #line default
        #line hidden
        
        
        #line 413 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem LogicTab;
        
        #line default
        #line hidden
        
        
        #line 433 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.KUErrors uiErrors;
        
        #line default
        #line hidden
        
        
        #line 439 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.TurnOnError uiTurnOnError;
        
        #line default
        #line hidden
        
        
        #line 444 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.FuseErrors uiFuseErrors;
        
        #line default
        #line hidden
        
        
        #line 457 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Meter uiMeter;
        
        #line default
        #line hidden
        
        
        #line 487 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Channels.ChannelsManagment uiChannelsManagment;
        
        #line default
        #line hidden
        
        
        #line 499 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.DiscretModules.AllStates uiStates;
        
        #line default
        #line hidden
        
        
        #line 514 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiPicon2ConfigurationViewTab;
        
        #line default
        #line hidden
        
        
        #line 518 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2.Picon2ConfigurationView uiPicon2ConfigurationView;
        
        #line default
        #line hidden
        
        
        #line 521 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiLogicConfigTab;
        
        #line default
        #line hidden
        
        
        #line 526 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Configuration.LogicConfig uiLogicConfig;
        
        #line default
        #line hidden
        
        
        #line 534 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem picon2ScheduleTab;
        
        #line default
        #line hidden
        
        
        #line 535 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2.Picon2LightingSheduleView picon2LightingSheduleView;
        
        #line default
        #line hidden
        
        
        #line 537 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiSheduleLightining;
        
        #line default
        #line hidden
        
        
        #line 544 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Schedule.Schedule uiLightingSchedule;
        
        #line default
        #line hidden
        
        
        #line 550 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiSheduleBackLight;
        
        #line default
        #line hidden
        
        
        #line 553 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Schedule.Schedule uiBacklightSchedule;
        
        #line default
        #line hidden
        
        
        #line 558 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiSheduleIllumination;
        
        #line default
        #line hidden
        
        
        #line 561 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Schedule.Schedule uiIlluminationSchedule;
        
        #line default
        #line hidden
        
        
        #line 567 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiSheduleEconomy;
        
        #line default
        #line hidden
        
        
        #line 570 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Schedule.Schedule uiEnergySchedule;
        
        #line default
        #line hidden
        
        
        #line 576 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiSheduleHeating;
        
        #line default
        #line hidden
        
        
        #line 579 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.HeatingSchedule.HeatingSchedule uiHeatingSchedule;
        
        #line default
        #line hidden
        
        
        #line 584 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiGPRSTab;
        
        #line default
        #line hidden
        
        
        #line 587 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.GPRS.GPRSConfiguration uiGPRSConfig;
        
        #line default
        #line hidden
        
        
        #line 593 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem MrNetwork;
        
        #line default
        #line hidden
        
        
        #line 598 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.MRNetworking.MRNetwork uiMrNetwork;
        
        #line default
        #line hidden
        
        
        #line 604 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem uiPicon2ModuleRequests;
        
        #line default
        #line hidden
        
        
        #line 609 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UniconGS.UI.Picon2.ModuleRequests.Picon2ModuleRequestsView Picon2ModuleRequest;
        
        #line default
        #line hidden
        
        
        #line 618 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle uiBackgrounder;
        
        #line default
        #line hidden
        
        
        #line 632 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid uiStateControl;
        
        #line default
        #line hidden
        
        
        #line 640 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image uiStateIcon;
        
        #line default
        #line hidden
        
        
        #line 645 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock uiStatePresenter;
        
        #line default
        #line hidden
        
        
        #line 653 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock uiAutonomusPresenter;
        
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
            System.Uri resourceLocater = new System.Uri("/PicGSConfig;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 25 "..\..\MainWindow.xaml"
            ((UniconGS.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.MainWindow_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.uiDeviceSelection = ((System.Windows.Controls.MenuItem)(target));
            
            #line 50 "..\..\MainWindow.xaml"
            this.uiDeviceSelection.Click += new System.Windows.RoutedEventHandler(this.uiDeviceSelection_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.uiConnect = ((System.Windows.Controls.MenuItem)(target));
            
            #line 55 "..\..\MainWindow.xaml"
            this.uiConnect.Click += new System.Windows.RoutedEventHandler(this.uiConnect_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.uiReconnect = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 5:
            this.uiAutonomous = ((System.Windows.Controls.MenuItem)(target));
            
            #line 61 "..\..\MainWindow.xaml"
            this.uiAutonomous.Click += new System.Windows.RoutedEventHandler(this.uiMenuAutonomus_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.uiDisconnect = ((System.Windows.Controls.MenuItem)(target));
            
            #line 64 "..\..\MainWindow.xaml"
            this.uiDisconnect.Click += new System.Windows.RoutedEventHandler(this.uiDisconnect_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.uiExit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 69 "..\..\MainWindow.xaml"
            this.uiExit.Click += new System.Windows.RoutedEventHandler(this.uiExit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.uiAbout = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 9:
            this.uiUsersGyde = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 10:
            this.PART_MAINBODY = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.uiMainControl = ((System.Windows.Controls.TabControl)(target));
            
            #line 84 "..\..\MainWindow.xaml"
            this.uiMainControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UiMainControl_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.uiHider = ((System.Windows.Controls.Border)(target));
            return;
            case 13:
            this.uiConnectBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 14:
            this.uiReconnectBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.uiAutonomousBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 16:
            this.uiDisconnectBtn = ((System.Windows.Controls.Button)(target));
            return;
            case 17:
            this.uiGSMConnection = ((System.Windows.Controls.Button)(target));
            
            #line 192 "..\..\MainWindow.xaml"
            this.uiGSMConnection.Click += new System.Windows.RoutedEventHandler(this.uiGSMConnection_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.DiagnosticTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 19:
            this.uiTime = ((UniconGS.UI.Time.Time)(target));
            return;
            case 20:
            this.uiScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 21:
            this.uiPiconDiagnostics = ((UniconGS.UI.PiconGSDiagnostics)(target));
            return;
            case 22:
            this.uiScrollViewerPicon2 = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 23:
            this.uiPicon2Diagnostics = ((UniconGS.UI.Picon2Diagnostic)(target));
            return;
            case 24:
            this.uiPicon2DiagnosticsErrors = ((UniconGS.UI.Picon2DiagnosticsErrors)(target));
            return;
            case 25:
            this.uiScrollPicon2ModuleErrors = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 26:
            this.uiPicon2ModuleErrors = ((UniconGS.UI.Picon2ModuleErrors)(target));
            return;
            case 27:
            this.uiDiagnosticsErrors = ((UniconGS.UI.DiagnosticsErrors)(target));
            return;
            case 28:
            this.uiScroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 29:
            this.uiRuno3Diagnostics = ((UniconGS.UI.Runo3Diagnostics)(target));
            return;
            case 30:
            this.uiSettings = ((UniconGS.UI.Settings.ControllerSettings)(target));
            return;
            case 31:
            this.uiSystemJournal = ((UniconGS.UI.Journal.SystemJournal)(target));
            return;
            case 32:
            this.uiSignalGSMLevel = ((UniconGS.UI.SignalGSMLevel)(target));
            return;
            case 33:
            this.LogicTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 34:
            this.uiErrors = ((UniconGS.UI.KUErrors)(target));
            return;
            case 35:
            this.uiTurnOnError = ((UniconGS.UI.TurnOnError)(target));
            return;
            case 36:
            this.uiFuseErrors = ((UniconGS.UI.FuseErrors)(target));
            return;
            case 37:
            this.uiMeter = ((UniconGS.UI.Meter)(target));
            return;
            case 38:
            this.uiChannelsManagment = ((UniconGS.UI.Channels.ChannelsManagment)(target));
            return;
            case 39:
            this.uiStates = ((UniconGS.UI.DiscretModules.AllStates)(target));
            return;
            case 40:
            this.uiPicon2ConfigurationViewTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 41:
            this.uiPicon2ConfigurationView = ((UniconGS.UI.Picon2.Picon2ConfigurationView)(target));
            return;
            case 42:
            this.uiLogicConfigTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 43:
            this.uiLogicConfig = ((UniconGS.UI.Configuration.LogicConfig)(target));
            return;
            case 44:
            this.picon2ScheduleTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 45:
            this.picon2LightingSheduleView = ((UniconGS.UI.Picon2.Picon2LightingSheduleView)(target));
            return;
            case 46:
            this.uiSheduleLightining = ((System.Windows.Controls.TabItem)(target));
            return;
            case 47:
            this.uiLightingSchedule = ((UniconGS.UI.Schedule.Schedule)(target));
            return;
            case 48:
            this.uiSheduleBackLight = ((System.Windows.Controls.TabItem)(target));
            return;
            case 49:
            this.uiBacklightSchedule = ((UniconGS.UI.Schedule.Schedule)(target));
            return;
            case 50:
            this.uiSheduleIllumination = ((System.Windows.Controls.TabItem)(target));
            return;
            case 51:
            this.uiIlluminationSchedule = ((UniconGS.UI.Schedule.Schedule)(target));
            return;
            case 52:
            this.uiSheduleEconomy = ((System.Windows.Controls.TabItem)(target));
            return;
            case 53:
            this.uiEnergySchedule = ((UniconGS.UI.Schedule.Schedule)(target));
            return;
            case 54:
            this.uiSheduleHeating = ((System.Windows.Controls.TabItem)(target));
            return;
            case 55:
            this.uiHeatingSchedule = ((UniconGS.UI.HeatingSchedule.HeatingSchedule)(target));
            return;
            case 56:
            this.uiGPRSTab = ((System.Windows.Controls.TabItem)(target));
            return;
            case 57:
            this.uiGPRSConfig = ((UniconGS.UI.GPRS.GPRSConfiguration)(target));
            return;
            case 58:
            this.MrNetwork = ((System.Windows.Controls.TabItem)(target));
            return;
            case 59:
            this.uiMrNetwork = ((UniconGS.UI.MRNetworking.MRNetwork)(target));
            return;
            case 60:
            this.uiPicon2ModuleRequests = ((System.Windows.Controls.TabItem)(target));
            return;
            case 61:
            this.Picon2ModuleRequest = ((UniconGS.UI.Picon2.ModuleRequests.Picon2ModuleRequestsView)(target));
            return;
            case 62:
            this.uiBackgrounder = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 63:
            this.uiStateControl = ((System.Windows.Controls.Grid)(target));
            return;
            case 64:
            this.uiStateIcon = ((System.Windows.Controls.Image)(target));
            return;
            case 65:
            this.uiStatePresenter = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 66:
            this.uiAutonomusPresenter = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

