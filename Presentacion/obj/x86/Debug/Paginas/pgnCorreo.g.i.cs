﻿#pragma checksum "..\..\..\..\Paginas\pgnCorreo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BC4F6B0CE4F2A582B59E7D4C406718E3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18033
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AgendaDigital.presentacion.Controles;
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


namespace AgendaDigital.presentacion.Paginas {
    
    
    /// <summary>
    /// pgnCorreo
    /// </summary>
    public partial class pgnCorreo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\Paginas\pgnCorreo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ucCorreo;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Paginas\pgnCorreo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AgendaDigital.presentacion.Controles.ucTextBoxMarcaAgua ucAsunto;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Paginas\pgnCorreo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEnviar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Paginas\pgnCorreo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCuerpo;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Paginas\pgnCorreo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Separator separator1;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentacion;component/paginas/pgncorreo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Paginas\pgnCorreo.xaml"
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
            this.ucCorreo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ucAsunto = ((AgendaDigital.presentacion.Controles.ucTextBoxMarcaAgua)(target));
            return;
            case 3:
            this.btnEnviar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Paginas\pgnCorreo.xaml"
            this.btnEnviar.Click += new System.Windows.RoutedEventHandler(this.btnEnviar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtCuerpo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.separator1 = ((System.Windows.Controls.Separator)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

