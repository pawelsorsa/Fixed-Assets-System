   M S B A M L   `   `   `  ����  FixedAssetsApp&     FixedAssetsApp.Views.SectionView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  SectionWindow��5      .��5   
   �� -   5        $��
stackPanel��5      .+�5      � .+�5	      � .+�5
      �� -   5        $��btn_GetAllSections��5
      $	��200��6T   .��6`   Wyświetl wszystkie sekcje6{   �� 5      -   5        $��btn_AddSection��5      $	��200��6H   .��6T   Dodaj nową sekcje6g   5      9� 5      $��Wyszukiwanie zaawansowane��6   .��5      �� -   5        $��expanderSearchSection��5      $��10,4,0,0q�6:   .+�5      �� .��6   ID:6!   � 5      .+�5      �� -   5        $
��tbId��5   "   $	��120��6.   $��0 0 15 0q�6:   6N   �� 5      -   5        $��
btnGetById��5   !   .��6R   
Wyszukaj6\   5      �� 5      .��6   Nazwa:6$   � 5      .+�5      �� -   5        $��tbName��5   "   $	��120��60   $��0 0 15 0q�6<   6P   �� 5      -	   5        $��btnGetByName��5   !   .��6T   
Wyszukaj6^   5      �� 5      .��6   	Skrót:6$   � 5      .+�5      �� -
   5        $��tbShortName��5   "   $	��120��65   $��0 0 15 0q�6A   6U   �� 5      -   5        $��btnGetShortName��5   !   .��6W   
Wyszukaj6a   5      �� 5      .��6   Ulica:6$   � 5      .+�5       �� -   5        $��tbStreet��5    "   $	��120��62   $��0 0 15 0q�6>   6R   �� 5!      -   5        $��btnGetByStreet��5!   !   .��6V   
Wyszukaj6`   5"      �� 5#      .��6   Kod pocztowy:6+   � 5$      .+�5%      �� -   5        $��tbPostalCode��5%   "   $	��120��66   $��0 0 15 0q�6B   6V   �� 5&      -   5        $��btnGetByPostalCode��5&   !   .��6Z   
Wyszukaj6d   5'      �� 5(      .��6   	Poczta:6%   � 5)      .+�5*      �� -   5        $��tbPost��5*   "   $	��120��60   $��0 0 15 0q�6<   6P   �� 5+      -   5        $��btnGetByPost��5+   !   .��6T   
Wyszukaj6^   5,      �� 5-      .��6   Miejscowość:6*   � 5.      .+�5/      �� -   5        $��
tbLocacity��5/   "   $	��120��64   $��0 0 15 0q�6@   6T   �� 50      -   5        $��btnGetByLocacity��50   !   .��6X   
Wyszukaj6b   51      �� 52      .��6   
Telefon:6&   � 53      .+�54      �� -   5        $��tbPhone��54   "   $	��120��61   $��0 0 15 0q�6=   6Q   �� 55      -   5        $��btnGetByPhone��55   !   .��6U   
Wyszukaj6_   56      �� 57      .��6   Email:6$   � 58      .+�59      �� -   5        $��tbEmail��59   "   $	��120��61   $��0 0 15 0q�6=   6Q   �� 5:      -   5        $��btnGetByEmail��5:   !   .��6U   
Wyszukaj6_   5;      �� 5<      $����6    �� 5=      $����6    5>      5?      5@      &   System.Windows.Controls.DataGrid  5A      -   5        $��dataGridSections��5A         AutoGenerateColumns .     AlternatingRowBackground
 �����$	��Top=�5B       �� AlternationCount$ 2��6+   $	��500��6@   $
��Auto��6P      CanUserAddRows .     
IsReadOnly .     Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6%      
IsReadOnly . 	   Header$	 ID��6D   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6P   �� *id+ �� Mode$ TwoWay=�6v     5F      $ * 6%    . $	 Nazwa��6A   
 6P   �� *name+$ TwoWay=�6y     5G      $
 Auto 6%    . $	 Skrót��6D   
 6S   �� *
short_name+$ TwoWay=�6�     5H      $
 Auto 6%    . $	 Ulica��6D   
 6S   �� *street+$ TwoWay=�6~     5I      $
 Auto 6%    . $	 Kod pocztowy��6D   
 6Z   �� *postal_code+$ TwoWay=�6�     5J      $
 Auto 6%    . $	 Poczta��6D   
 6T   �� *post+$ TwoWay=�6}     5K      $
 Auto 6%    . $	 Miejscowość��6D   
 6Y   �� *
locality+$ TwoWay=�6�     5L      $
 Auto 6%    . $	 Telefon��6D   
 6U   �� *phone_number+$ TwoWay=�6�     5M      $
 Auto 6%    . $	 Email��6D   
 6S   �� *email+$ TwoWay=�6}   4  .System.Windows.Controls.DataGridTemplateColumn  5N      $
 Auto 6)   $	 Usuń��66      CellTemplate 5O      �� 5P      .R�5Q      �� $��	btnDelete��5R   4   $��Delete��5Q   %   $��Usuń��5R   %   6G   5S      5U        5V      $
 Auto 6)   $	 Edytuj��66    5W      �� 5X      .R�5Y      �� $��	btnUpdate��66   -   5        $��Edytuj��5Y   %   6a   5Z      5\      5^      5_      5`      