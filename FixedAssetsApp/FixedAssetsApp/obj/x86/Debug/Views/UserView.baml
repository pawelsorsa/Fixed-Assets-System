   M S B A M L   `   `   `  ����  FixedAssetsApp#    FixedAssetsApp.Views.UserView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �� .+�5	   
   � .+�5
      �� -   5        $��btn_GetAllUsers��5
      $	��200��6J   .��6V   %#Wyświetl wszystkich użytkowników6x   �� 5      -   5        $��btn_AddUser��5      $	��200��6B   .��6N   Dodaj nowego użytkownika6h   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridUsers��5          AutoGenerateColumns  .     AlternatingRowBackground
 �����$	��Top=�5       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      
IsReadOnly .    Header$ Login��6A   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6P   �� *login+
 �� Mode$
 TwoWay=�6z     5      $ * 6%    . $ Email��6A   	 6P   �� *email+$
 TwoWay=�6z     5      $ * 6%    . $ Imię��6A   	 6O   �� *name+$
 TwoWay=�6x     5      $ * 6%    . $ Nazwisko��6A   	 6S   �� *	surname+$
 TwoWay=�6     5      $ * 6%    . $ Data utworzenia��6A   	 6Z   �� *creation_date+$
 TwoWay=� �� StringFormat$ {0:dd-MM-yyyy}��6�     5      $ * 6%    . $ Data ost. logowania��6A   	 6^   �� *last_login_date+$
 TwoWay=�$ {0:dd-MM-yyyy}��6�     5      $ * 6%    . $ Aktywny��6A   	 6R   �� *	is_active+$
 TwoWay=�6�     5      $ * 6%    . $ PLKLogin��6A   	 6S   �� *
PLKLogin+$
 TwoWay=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6)   $ Usuń��66      CellTemplate 5      �� 5      .R�5      �� $��	btnDelete��5   4   $��Delete��5   %   $��Usuń��5   %   6G   5      5!        5"      $
 Auto 6)   $ Edytuj��66    5#      �� 5$      .R�5%      �� $��	btnUpdate��66   -   5        $��Edytuj��5%   %   6a   5&      5(      5*      5,      5-      