﻿#pragma checksum "..\..\..\..\StartMenu\QuickLink.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5ACCF4BD0B298E95DE660DF63B651D91"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Advent.Common.UI;
using Advent.VmcStudio;
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


namespace Advent.VmcStudio.StartMenu {
    
    
    /// <summary>
    /// QuickLink
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class QuickLink : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advent.VmcStudio.StartMenu.QuickLink m_quickLink;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image m_backgroundImage;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image m_linkImage;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image m_focusImage;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox m_isEnabledCheck;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advent.VmcStudio.ImageButton m_deleteButton;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\StartMenu\QuickLink.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Advent.VmcStudio.EditableTextBlock m_titleText;
        
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
            System.Uri resourceLocater = new System.Uri("/Media Center Studio;component/startmenu/quicklink.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\StartMenu\QuickLink.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.m_quickLink = ((Advent.VmcStudio.StartMenu.QuickLink)(target));
            
            #line 3 "..\..\..\..\StartMenu\QuickLink.xaml"
            this.m_quickLink.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.QuickLink_MouseUp);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\..\StartMenu\QuickLink.xaml"
            this.m_quickLink.AddHandler(Advent.Common.UI.DragDrop.DragEvent, new Advent.Common.UI.BeginDragEventHandler(this.OnDrag));
            
            #line default
            #line hidden
            return;
            case 2:
            this.m_backgroundImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.m_linkImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.m_focusImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.m_isEnabledCheck = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.m_deleteButton = ((Advent.VmcStudio.ImageButton)(target));
            return;
            case 7:
            this.m_titleText = ((Advent.VmcStudio.EditableTextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
