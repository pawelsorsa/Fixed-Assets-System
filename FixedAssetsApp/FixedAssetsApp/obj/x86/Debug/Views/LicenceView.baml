   M S B A M L   `   `   `  ����  FixedAssetsApp&     FixedAssetsApp.Views.LicenceView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �� .+�5   
   � .+�5	      �� -   5        $��btn_GetAllLicences��5	      $	��200��6P   .��6\   Wyświetl wszystkie licencję6y   �� 5
      -   5        $��btn_AddLicence��5
      $	��200��6H   .��6T   Dodaj nową licencję6i   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridLicences��5          AutoGenerateColumns  .     AlternatingRowBackground
 �����$	��Top=�5       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      
IsReadOnly .    Header$ ID��6D   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6P   �� *	id_number+
 �� Mode$
 TwoWay=�6}     5      $
 Auto 6%    . $ Numer inwentarzowy��6D   	 6`   �� *inventory_number+$
 TwoWay=�6�     5      $
 Auto 6%    . $  Przypisany środek trwały��6D   	 6f   �� *assign_fixed_asset+$
 TwoWay=�6�     5      $
 Auto 6%    . $ Numer licencji��6D   	 6\   �� *licence_number+$
 TwoWay=�6�     5      $ * 6%    . $
 Name��6A   	 6O   �� *name+$
 TwoWay=�6x     5      $
 Auto 6%    . $ Utworzone przez��6D   	 6]   �� *
created_by+$
 TwoWay=�6�     5      $
 Auto 6%    . $ Ostatnia modyfikacja��6D   	 6b   �� *last_modified_date+ �� StringFormat$ d��$
 TwoWay=�6�     5      $
 Auto 6%    . $! Ostatnio modyfikowane przez��6D   	 6i   �� *last_modified_login+$
 TwoWay=�6�     5      $
 Auto 6%    . $ 	Komentarz��6D   	 6W   �� *	comment+$
 TwoWay=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6)   $ Usuń��66      CellTemplate 5      �� 5      .R�5      �� $��	btnDelete��5   4   $��Delete��5   %   $��Usuń��5   %   6G   5      5         5!      $
 Auto 6)   $ Edytuj��66    5"      �� 5#      .R�5$      �� $��	btnUpdate��66   -   5        $��Edytuj��5$   %   6a   5%      5'      5)      5*      5+      