   M S B A M L   `   `   `  ����G  CPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:AgendaDigital.presentacion.Controles$AgendaDigital.presentacion.Controles  5      5    /AgendaDigital.presentacion.Paginas.PgnPrincipal   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Amy2clr-namespace:AgendaDigital.presentacion.Controles     5        N� Title$  PgnPrincipal��6   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
    � -   5        $��frmMantenimiento��5      $��	0,111,0,0q�6(     � NavigationUIVisibility$ Hidden=�6;   $��Center=�6[   $��Center=�6   �� 5   
   ���	#FF12869D$��105.05��6%   ���	#FF1A9DB6$	��Top=�6H   �� 5   
   -   5        $��
btnGuardar��5   #   $��Button��6   $��42��65   $��
0,18,376,0q�6A   $	��Top=�6U      Guardar#���   6m   $��Right=�6�   $��42��6�     guardar � ToolTip# �  6�   �� 5   
   -   5        $��
btnAgregar��5   "   $��Button��6   $��Right=�64   $��42��6P   $��
0,18,422,0q�6\   $	��Top=�6p   $��42��6�     Agregar#���  6�    	 Nuevo# �  6�   6�   �� 5   
   -   5        $��btnEliminar��5   "   $��Button��6   $��42��65   $��
0,18,284,0q�6A   $	��Top=�6U     eliminar#���  6m   $��Right=�6�   $��42��6�     Eliminar# �  6�   {�. 6�   �� 5   
   -   5        $��	btnCorreo��5   "   $��Button��6   $��42��63   $��	0,18,29,0q�6?   $	��Top=�6R     mensaje#���  6j   $��Right=�6�   $��42��6�    
 Correo# �  6�   �� 5   
   -   5        $��btnFavorito��5   "   $��Button��6   $��	0,18,75,0q�65     favorito#���  6H   $��42��6k   $	��Top=�6w   $��Right=�6�   $��42��6�    	 	Favoritos# � 	 6�   6�   �� 5   
   -   5        $��btnCancelar��5   "   $��Button��6   $��
0,18,238,0q�65    
 cancelar#��� 
 6I   $��42��6l   $	��Top=�6x   $��Right=�6�   $��42��6�     Cancelar# �  6�   6�   �� 5   
   -   5        $��
separator1��5   6   $��54��6   $��0,11.5,156,0q�6    $	��Top=�6H    J� RenderTransformOrigin$ 0.5,0.5&�6`   $��Right=�6�   $��38��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -90.021Q�6&   T� 5      5      5      �� 5    
   -	   5        $��	btnEditar��5    "   $��Button��6   $��42��63   $��
0,18,330,0q�6?   $	��Top=�6S   $��42��6k    
 editar#���  6v   $��Right=�6�    
 Editar# �  6�   �� 5!   
   $��42��6   $��	61,32,0,0q�6    $
��Wrap=�63     AgendaDigital#���  6G   $	��Top=�6n   $
��Left=�6�   $	��239��6�   ���	#FFFFF9F9$��24(�6�   �� 5"   
   $
��Left=�6   $��56��6+   $��1,18,0,0q�67   $6��0/Presentacion;component/Imagenes/Login/icono.png��6I   $
��Fill=�6�   $	��Top=�6�   $��56��6�   0   *AgendaDigital.presentacion.Controles.ucAbc  5$   
   -
   5          Name$ ucAbc1��5$   %   $��0,81,0,0q�6   6%   �� 5%   
   -   5        $��btnAgregarU��5%   ^   $��Button��6   $��42��6"   $��Right=�6.   $��
0,18,192,0q�6J   $	��Top=�6q   $��42��6�     guardarUsuario#��[ 6�     AgregarUsuario# �  6�   6  o� 5&   
   -   5        $��menu1��5&   K   $��42��6   $��Right=�6   $��
0,17,125,0q�67   $	��Top=�6X   $��42��6p   ��5'      �� 5(       �� ImageSource$= 7/Presentacion;component/Imagenes/PagPrincipal/grupo.png��6   .@�5*      m� -   5        $��mItems��5*   .   $��42��6   $��42��6"    
 Grupos# �  6<   .@�5+      m� -   5          Mantenimiento#���  5+      6D   m� 5,      -   5          Filtrar#���  5,      6>   5-      5.      5/      50      