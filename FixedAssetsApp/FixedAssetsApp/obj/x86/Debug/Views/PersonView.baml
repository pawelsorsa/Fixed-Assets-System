   M S B A M L   `   `   `  ����I  EFixedAssetsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:FixedAssetsApp.UserControllsFixedAssetsApp.UserControlls  5      %    FixedAssetsApp.Views.PersonView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9uc*clr-namespace:FixedAssetsApp.UserControlls     5      .��5      �� .+�5	   
   � .+�5
      � .+�5      �� -   5        $��btnCreateNewPerson��5      .��6Q   Dodaj nowego pracownika6j   5      2   ,FixedAssetsApp.UserControlls.ExpandersPerson  5      -   5           Name$  expanderPerson��5   !   6;   5      &   System.Windows.Controls.DataGrid  5      -   5        $��dataGridPersons��5   Y   $	��500��6   $
��Auto��6'   ��.    AutoGenerateColumns .     AlternatingRowBackground
 ����� �� AlternationCount$ 2��6�   $	��Top=�5         CanUserAddRows .     
IsReadOnly .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      
IsReadOnly . 	   Header$	 ID��6D   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6P   �� *id+ �� Mode$ TwoWay=�6v     5      $ * 6%    . $	 Imię��6A   
 6O   �� *name+$ TwoWay=�6x     5      $ * 6%    . $	 Nazwisko��6A   
 6S   �� *	surname+$ TwoWay=�6     5      $
 Auto 6%    . $	 
Kiernukowy��6D   
 6X   �� *	area_code+$ TwoWay=�6�     5      $
 Auto 6%    . $	 Telefon��6D   
 6U   �� *phone_number+$ TwoWay=�6�     5      $
 Auto 6%    . $	 Tel. komórkowy��6D   
 6\   �� *phone_number2+$ TwoWay=�6�     5      $
 Auto 6%    . $	 Email��6D   
 6S   �� *email+$ TwoWay=�6}     5      $
 Auto 6%    . $	 Sekcja��6D   
 6T   �� *short_section_name+$ TwoWay=�6�   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6)   $	 Usuń��66      CellTemplate 5      �� 5      .R�5      �� $��	btnDelete��5   4   $��Delete��5   %   $��Usuń��5   %   6H   5       5"        5#      $
 Auto 6)   $	 Edytuj��66    5$      �� 5%      .R�5&      �� $��	btnUpdate��66   -   5        $��Edytuj��5&   %   6g   5'      5)      5+      5,      5.      