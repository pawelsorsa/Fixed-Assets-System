﻿#pragma checksum "..\..\..\..\UserControlls\Navigation.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D5D60195414D73163D5E77BA70110C80"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
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


namespace FixedAssetsApp.UserControlls {
    
    
    /// <summary>
    /// Navigation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Navigation : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelNavigation;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel log;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Login;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Password;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogon;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\UserControlls\Navigation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogOut;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FixedAssetsApp;component/usercontrolls/navigation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UserControlls\Navigation.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.labelNavigation = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.log = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 3:
            this.tb_Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_Password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnLogon = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\UserControlls\Navigation.xaml"
            this.btnLogon.Click += new System.Windows.RoutedEventHandler(this.btnLogon_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\UserControlls\Navigation.xaml"
            this.btnLogOut.Click += new System.Windows.RoutedEventHandler(this.btnLogOut_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

