﻿#pragma checksum "..\..\..\PageAdmin\PageAddTarifs.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CA16316E3B8E8E9F02B1779A4EBEAEAD72D9298D9C6D4DDB02FB92288B1210B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SPTC.PageAdmin;
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


namespace SPTC.PageAdmin {
    
    
    /// <summary>
    /// PageAddTarifs
    /// </summary>
    public partial class PageAddTarifs : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_name;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_amount;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_price;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_provider;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_desc;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_add;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_image;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\PageAdmin\PageAddTarifs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_type;
        
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
            System.Uri resourceLocater = new System.Uri("/SPTC;component/pageadmin/pageaddtarifs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PageAdmin\PageAddTarifs.xaml"
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
            this.txb_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txb_amount = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\PageAdmin\PageAddTarifs.xaml"
            this.txb_amount.SelectionChanged += new System.Windows.RoutedEventHandler(this.txb_amount_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txb_price = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\PageAdmin\PageAddTarifs.xaml"
            this.txb_price.SelectionChanged += new System.Windows.RoutedEventHandler(this.txb_price_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cb_provider = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txb_desc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_add = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\PageAdmin\PageAddTarifs.xaml"
            this.btn_add.Click += new System.Windows.RoutedEventHandler(this.btn_add_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\PageAdmin\PageAddTarifs.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.btn_back_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_image = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\PageAdmin\PageAddTarifs.xaml"
            this.btn_image.Click += new System.Windows.RoutedEventHandler(this.btn_image_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cb_type = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

