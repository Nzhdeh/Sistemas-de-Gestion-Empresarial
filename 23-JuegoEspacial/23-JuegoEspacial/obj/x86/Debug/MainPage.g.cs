﻿#pragma checksum "D:\Sistemas-de-Gestion-Empresarial\23-JuegoEspacial\23-JuegoEspacial\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E51A89A7306FC0F27E6639FA6F0F1180"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _23_JuegoEspacial
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::_23_JuegoEspacial.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.Image obj10;

            // Fields for each event bindings event handler.
            private global::Windows.UI.Xaml.Input.KeyEventHandler obj10KeyDown;
            private global::Windows.UI.Xaml.Input.KeyEventHandler obj10KeyUp;

            // Static fields for each binding's enabled/disabled state

            public MainPage_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 105 && columnNumber == 8)
                {
                    this.obj10.KeyDown -= obj10KeyDown;
                }
                else if (lineNumber == 105 && columnNumber == 59)
                {
                    this.obj10.KeyUp -= obj10KeyUp;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 10: // MainPage.xaml line 104
                        this.obj10 = (global::Windows.UI.Xaml.Controls.Image)target;
                        this.obj10KeyDown = (global::System.Object p0, global::Windows.UI.Xaml.Input.KeyRoutedEventArgs p1) =>
                        {
                            this.dataRoot.vMGame.Grid_KeyDown(p0, p1);
                        };
                        ((global::Windows.UI.Xaml.Controls.Image)target).KeyDown += obj10KeyDown;
                        this.obj10KeyUp = (global::System.Object p0, global::Windows.UI.Xaml.Input.KeyRoutedEventArgs p1) =>
                        {
                            this.dataRoot.vMGame.Grid_KeyUp(p0, p1);
                        };
                        ((global::Windows.UI.Xaml.Controls.Image)target).KeyUp += obj10KeyUp;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                throw new global::System.NotImplementedException();
            }

            public void Recycle()
            {
                throw new global::System.NotImplementedException();
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::_23_JuegoEspacial.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::_23_JuegoEspacial.MainPage obj, int phase)
            {
                if (obj != null)
                {
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 18
                {
                    this.animacionEstrellasFrente = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3: // MainPage.xaml line 26
                {
                    this.animacionEstrellasMedio = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4: // MainPage.xaml line 34
                {
                    this.animacionEstrellasFondo = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 5: // MainPage.xaml line 42
                {
                    this.animacionAvion = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 6: // MainPage.xaml line 51
                {
                    this.sp1 = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                    ((global::Windows.UI.Xaml.Controls.Canvas)this.sp1).Loaded += this.allowfocus_Loaded;
                }
                break;
            case 7: // MainPage.xaml line 52
                {
                    this.estrellasFrente = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 8: // MainPage.xaml line 69
                {
                    this.estrellasMedio = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 9: // MainPage.xaml line 86
                {
                    this.estrellasFondo = (global::Windows.UI.Xaml.Shapes.Path)(target);
                }
                break;
            case 10: // MainPage.xaml line 104
                {
                    this.stkJugador1 = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

