   M S B A M L   `   `   `  ����  FixedAssetsApp'    !FixedAssetsApp.Views.SubgroupView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  Podgrupy��5      .��5      �� .+�5   
   � .+�5	      �� -   5        $��btn_GetAllSubgroup��5	      $	��200��6Q   .��6]   Wyświetl wszystkie podgrupy6z   �� 5
      -   5        $��btn_AddSubgroup��5
      $	��200��6J   .��6V   Dodaj nową podgrupę6k   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGridSubgroups��5         AutoGenerateColumns .     AlternatingRowBackground
 �����$	��Top=�5       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      
IsReadOnly . 	   Header$	 ID��6D   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6P   �� *id+ �� Mode$ TwoWay=�6v     5      $ * 6%    . $	 Skrót��6A   
 6P   �� *
short_name+$ TwoWay=�6     5      $ * 6%    . $	 Nazwa��6A   
 6P   �� *name+$ TwoWay=�6y   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 Auto 6)   $	 Usuń��66      CellTemplate 5      �� 5      .R�5      �� $��	btnDelete��5   4   $��Delete��5   %   $��Usuń��5   %   6G   5      5        5      $
 Auto 6)   $	 Edytuj��66    5      �� 5      .R�5      �� $��	btnUpdate��66   -   5        $��Edytuj��5   %   6a   5      5!      5#      5$      5%      