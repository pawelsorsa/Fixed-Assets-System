   M S B A M L   `   `   `  ����I  EFixedAssetsApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:FixedAssetsApp.FixedAssetsWebService$FixedAssetsApp.FixedAssetsWebService  5   	   E'clr-namespace:FixedAssetsApp.ValidationFixedAssetsApp.Validation  5   	   E'clr-namespace:FixedAssetsApp.ConvertersFixedAssetsApp.Converters  5   	   )    #FixedAssetsApp.Views.PersonEditView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @c2clr-namespace:FixedAssetsApp.FixedAssetsWebService     5   	   >
validators'clr-namespace:FixedAssetsApp.Validation     5   	   9local'clr-namespace:FixedAssetsApp.Converters     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   ?    � Title$ 	Pracownik��5   	   $	��600��64   $	��700��6@   $	��600��6M   $	��700��6\    � 	Resources 5      D   >FixedAssetsApp.Converters.ErrorCollectionToVisibilityConverter   ToVisibility �� 
TargetType �� Property �� Value��%q   &	        '��        5	   
   65   �� 5
   
   " ��6   .�5      ��  � ��
 �  ��6+   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ ApplicationCommands.Close��5      5      .��5      �� -   5         ��Name$ PersonEditScroll��5   _   $��Hidden=�6   $��Hidden=�68   ��. .��5   
   � -   5        $��Grid_EditPerson��5      	 � ShowGridLines	 . .+�5      �� -   5        $��stackAddUser��5      $��10,4,0,0q�6.   .+�5      �� -   5        $��AddOrEditPerson��5      $��22(�6/   $��Italic$�6=   6R   �� 5      .��6   ID:6   � 5      .+�5      �� -   5        $��tbAddUser_Id��5      $	��200��6.   $��	0 0 15 10q�6:   .��6M   .��5      �� 
 �� Path$
 id�6"    �� UpdateSourceTrigger$ PropertyChanged=�6,    �� Mode$ TwoWay=�6R    �� ValidationRules 5      :   4FixedAssetsApp.Validation.IntegerRangeValidationRule  5      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    Minimum$ 1��5   )      Maximum$ 1000000��65      ErrorMessage$( "Podaj liczbę z zakresu 0 - 10000.��5   )   5       5!      �� 5"      y�6   ��  �� ElementName$ tbAddUser_Id��$
 (Validation.Errors)� �� 	Converter# [  ��5#      `� 5$       �� StringFormat$
  {0}��6#   .1�5%      �� $ tbAddUser_Id��6"   $)
 #(Validation.Errors)[0].ErrorContent�6=   5&      5(      5)      �� 5*      .��6   Imię:6   � 5+      .+�5,      �� -   5        $��tbAddUser_Name��5,      $	��200��61   $��	0 0 15 10q�6=   .��6Q   .��5-      �� $

 name�6"   $ PropertyChanged=�6.   $ TwoWay=�6T    5.      9   3FixedAssetsApp.Validation.StringRangeValidationRule  5/       .    MinimumLength$ 2��50   )      MaximumLength$ 15��51   )      ErrorMessage$6 0Pole imię powinno zawierać od 2 do 15 znaków.��52   )   54      55      �� 56      y�6    �� $ tbAddUser_Name��$
 (Validation.Errors)�# [  ��57      `� 58      $
  {0}��6#   .1�59      �� $ tbAddUser_Name��6"   $)
 #(Validation.Errors)[0].ErrorContent�6?   5:      5<      5=      �� 5>      .��6   	Nazwisko:6#   � 5?      .+�5@      �� -	   5        $��tbAddUser_Surname��5@      $	��200��67   $��	0 0 15 10q�6C   .��6V   .��5A      �� $
 surname�6"   $ PropertyChanged=�61   $ TwoWay=�6W    5B        5C       . $ 2��5D   )   $ 15��5E   )   $9 3Pole nazwisko powinno zawierać od 2 do 15 znaków.��5F   )   5H      5I      �� 5J      y�6    �� $ tbAddUser_Surname��$
 (Validation.Errors)�# [  ��5K      `� 5L      $
  {0}��6#   .1�5M      �� $ tbAddUser_Surname��6"   $)
 #(Validation.Errors)[0].ErrorContent�6B   5N      5P      5Q      �� 5S      .��6   Email:6    � 5T      .+�5U      �� -
   5        $��tbAddUser_Email��5U   "   $	��200��69   $��	0 0 15 10q�6E   .��6X   .��5V      �� $
 email�6"   $ PropertyChanged=�6/   $ TwoWay=�6U    5W   "   3   -FixedAssetsApp.Validation.RegexValidationRule  5X   "    .    Empty .    ErrorMessage$2 ,Podany adres email ma nieprawidłowy format.��5Y   )      	TypeRegax$ email��6d   5[      5\      �� 5]      y�6$   �� $ tbAddUser_Email��$
 (Validation.Errors)�# [  ��5^      `� 5_      $
  {0}��6#   .1�5`      �� $ tbAddUser_Email��6"   $)
 #(Validation.Errors)[0].ErrorContent�6@   5a      5c      5d      �� 5f      .��6   Numer kierunkowy:6+   � 5g      .+�5h      �� -   5        $��tbAddUser_AreaCode��5h      $	��200��64   $��	0 0 15 10q�6@   .��6S   .��5i      �� $
 	area_code�6"    �� TargetNullValue$  ��63   $ PropertyChanged=�6F   $ TwoWay=�6l    �� ValidatesOnDataErrors .   5j      ;   5FixedAssetsApp.Validation.IntegerLengthValidationRule  5k   "    .    Minimum$ 2��5l   )      Maximum$ 2��65      Empty .      ErrorMessage$3  -Pole nr. kierunkowy powinno zawierać 2 znaki��5m   )   5o      5p      �� 5q      y�6    �� $ tbAddUser_AreaCode��$
 (Validation.Errors)�# [  ��5r      `� 5s      $
  {0}��6#   .1�5t      �� $ tbAddUser_AreaCode��6"   $)
 #(Validation.Errors)[0].ErrorContent�6C   5u      5w      5x      �� 5z      .��6   
Telefon:6"   � 5{      .+�5|      �� -   5        $��tbAddUser_Phone��5|      $	��200��62   $��	0 0 15 10q�6>   .��6Q   .��5}      �� $
 phone_number�6"   $ PropertyChanged=�66   $ TwoWay=�6\    5~        5   "    . $ 7��5�   )   $ 7��65    .  $.  (Pole telefon powinno zawierać 7 znaków��5�   )   5�      5�      �� 5�      y�6    �� $ tbAddUser_Phone��$
 (Validation.Errors)�# [  ��5�      `� 5�      $
  {0}��6#   .1�5�      �� $ tbAddUser_Phone��6"   $)
 #(Validation.Errors)[0].ErrorContent�6@   5�      5�      5�      �� 5�      .��6   Telefon komórkowy:6,   � 5�      .+�5�      �� -   5        $��tbAddUser_Phone2��5�      $	��200��66   $��	0 0 15 10q�6B   .��6U   .��5�      �� $
 phone_number2�6"   $ PropertyChanged=�67   $ TwoWay=�6]   $  ��6k    5�        5�   "    . $ 9��5�   )   $ 9��65    . $9  3Pole telefon komórkowy powinno zawierać 9 znaków��5�   )   5�      5�      �� 5�      y�6   �� $ tbAddUser_Phone2��$
 (Validation.Errors)�# [  ��5�      `� 5�      $
  {0}��6#   .1�5�      �� $ tbAddUser_Phone2��6"   $)
 #(Validation.Errors)[0].ErrorContent�6A   5�      5�      5�      �� 5�      .��6   	Sekcja:6!   � 5�      .+�5�      �� -   5        $��ComboBox_Sections��5�   2   $��	0 0 15 10q�6   $	��Top=�5�      $	��200��61   ! �� Text$! Wybierz sekcje��6=   6�   �� 5�      $����6    5�      � 5�      $��Center=�6   .+�5�      �� -   5        $��button_Close��5�      $��Anuluj��5�      $	��110��6.   $��60��6:   $��5q�6F   $��	10,3,10,3q�6Q   $��Close��6e   $	��Top=�5�   -   6G   �� 5�      -   5        $��button_Save��5�      $��Zapisz��5�      $	��110��6.   $��60��6:   $��5q�6F   $��	10,3,10,3q�6Q   $	��Top=�5�   ,   ��5�      �� 5�      " ��6    .�5�      ��  � {� .  6:   " �� Triggers" 5�      ^� 5�   "   # ^� 
Conditions# 5�   &   �� 5�   *   $ �� Binding$ 64   �� $ tbAddUser_Id��$
 (Validation.HasError)�% �� Value	% false6}   �� 5�   *   $ 64   �� $ tbAddUser_Name��$
 (Validation.HasError)�	% false6   �� 5�   *   $ 64   �� $ tbAddUser_Surname��$
 (Validation.HasError)�	% false6�   �� 5�   *   $ 64   �� $ tbAddUser_Email��$
 (Validation.HasError)�	% false6�   �� 5�   *   $ 64   �� $ tbAddUser_AreaCode��$
 (Validation.HasError)�	% false6�   �� 5�   *   $ 64   �� $ tbAddUser_Phone��$
 (Validation.HasError)�	% false6�   �� 5�   *   $ 64   �� $ tbAddUser_Phone2��$
 (Validation.HasError)�	% false6�   .0�5�   &   ��  � {� . 6B   5�   #   5�      5�      5�      5�      5�      5�      5�      