   M S B A M L   `   `   `  ����G  CPresentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:AgendaDigital.presentacion.Controles$AgendaDigital.presentacion.Controles  5      <    6AgendaDigital.presentacion.Paginas.pgnRegistrarUsuario   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Amy2clr-namespace:AgendaDigital.presentacion.Controles     5      -   5          N� Title$  pgnRegistrarUsuario��5      .��5
      �  � RowDefinitions 5   
   �� 5      $	��37* �6   �� 5      $
��210* �6   �� 5      $	��53* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $	��361 �6   �� 5      $
��0.5* �6   .+�5   
   �� -   5        $��label1��5   I      	NomCuenta#���   6   $��	14,18,0,0q�66   $��16(�6W   $��35��6e   $	��Top=�6q   $��1��6�   $��1��6�   $
��Left=�6�   $	��168��6�   �� 5   
   -   5        $��label2��5   R    
 Contra#���  6   $��35��63   $��	14,51,0,0q�6?   $	��Top=�6`   $��16(�6x   $��1��6�   $��1��6�   $
��Left=�6�   $��99��6�   �� 5   
   -   5        $��	txtnombre��5   &   $��
188,18,0,0q�6   $��27��68   $	��Top=�6D   $��1��6\   $��1��6l   $
��Left=�6y   $	��162��6�   :   4AgendaDigital.presentacion.Controles.ucPassMarcaAgua  5   
   -   5          Name$ ucPass1��5   1   $��
188,51,0,0q�6   $��27��6B   $	��Top=�6N   $��1��6f   $��1��6v   $
��Left=�6�   $	��162��6�   �� 5   
   -   5        $��label3��5   S     Vcontra#���  6   $��37��64   $��	14,84,0,0q�6@   $	��Top=�6a   $��16(�6y   $��1��6�   $��1��6�   $
��Left=�6�   $	��168��6�     5   
   -   5        $ ucPass��5   1   $��
188,84,0,0q�6   $��27��6A   $	��Top=�6M   $��1��6e   $��1��6u   $
��Left=�6�   $	��162��6�   �� 5   
   -   5        $��
separator1��5      $��59��6&   $	��Top=�62   $��	1,106,0,0q�6J   $��1��6]   $��1��6m   $
��Left=�6z   $	��360��6�   �� 5   
   -	   5        $��txterror��5   5   $��21��6   $��188,116,0,0q�6     5 1Las contraseñas no coinciden o hay campos vacios#���  6E   $	��Top=�6�   $y�Hidden=�6�   ���	#FFFF0404$��1��6�   $��1��6�   $
��Left=�6�   $	��313��6
  $��2��6  �� 5   
   -
   5        $��imgError��5   1   $��13��6   $��168,120,0,0q�6   $
��Fill=�6A   $	��Top=�6P   $9��3/Presentacion;component/Imagenes/Mensajes/error.png��6h   $y�Hidden=�6�   $��1��6�   $��1��6�   $
��Left=�6�   $��14��6�   5      5      