   M S B A M L   `   `   `  ����D  @AgendaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AgendaWPF.ViewsAgendaWPF.Views  5      #    AgendaWPF.Views.CustomersList   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:AgendaWPF.Views     5        N� Title$  Liste des clients��5	      .��5      ]� .+�5   
   �� -   5        $��	buttonBar��5       �� Orientation$ 
Horizontal=�6&   $��Right=�6?    � LayoutTransform 5      �� 5       �� Angle$ 90Q�6"   .+�5      �� -   5        $��btnOne��5      $��0,0,5,0q�6B   $��	10,1,10,1q�6S   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FFFFE800��6'    � Offset$ 0Q�69   � 5      $ 	#FFFCFCFC��6'   $ 0.537Q�69   5      .��5   %   Modifier Client5      5      � 5   
   -   5        $��
parentGrid��5      .+�5       � -   5        $��layer0��5       .+�5!      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5!         AlternatingRowBackground
 ��ح�	 �� AlternationCount$	 2��5"      
   AutoGenerateColumns$
 False��6)      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Lastname��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
Lastname+ �� Mode$ TwoWay=�  5%      $ 	Firstname��6-    6B   �� *	Firstname+$ TwoWay=�  5&      $
 Mail��6-    6=   �� *Mail+$ TwoWay=�  5'      $ PhoneNumber��6-    6D   �� *PhoneNumber+$ TwoWay=�  5(      $ Budget��6-    6?   �� *Budget+$ TwoWay=�4  .System.Windows.Controls.DataGridTemplateColumn  5)      $
 View��61      CellTemplate 5*      �� 5+   "   .R�5,   &   �� $��btnView��6-   -   5        $
��View��5,   <   6K   5-   #   5/      51      52      � 57      -   5        $��
gridlayer1��57      $y�	Collapsed=�6%    � ColumnDefinitions 58      �� 59      �� 5:       z� SharedSizeGroup$ column1��6'   $
��auto �6A   .+�5>      � $��1��6   
����ح� � RowDefinitions 5A      �� 5B      $
��auto �6(   �� 5C      .+�5F      ]� $��0��6    .+�5G      �� -   5        $��	panel1Pin��5G   ,   $��26��6!   $��Right=�6=   
�������.��5H      �� -	   5        $��panel1PinImg��5H   $   $��/Images/HorizontalPin.png��68   5I      �� 5L       �� Padding$
 25,8q�6$   $��CharacterEllipsis=�63   
���   �$
��Left=�6g   
Formulaire6�   5N      �� 5P      -
   5        $��listBoxForm��5P   8   $��10q�6   $��1��6+   .@�5Q      �� -   5        $��	errorForm��5Q   %   68   �� 5R      -   5        $��txtIdCustomer��5R   .   $��23��6"   $��50��6C   $y�Hidden=�6N    �� 
IsReadOnly$
 True��6b   �� 5S      $	��Nom��6&   �� 5T      -   5        $��txtLastname��5T   .   $��23��6"   $	��150��6A   $�� ��6M   �� 5U      $��Prénom��6&   �� 5V      -   5        $��txtFirstname��5V   .   $��23��6"   $	��150��6B   $�� ��6N   �� 5W      $��Email��6'   �� 5X      -   5        $��txtMail��5X   .   $��23��6"   $	��150��6=   $�� ��6I   �� 5Y      $	��Tel��6'   �� 5Z      -   5        $��txtPhonenumber��5Z   .   $��23��6"   $	��150��6D   $�� ��6P   �� 5[      $��Budget��6&   �� 5\      -   5        $��	txtBudget��5\   .   $��23��6"   $	��150��6?   $�� ��6K   �� 5]      -   5        $��Modifier��5]   !   6I   �� 5^      -   5        $��	Supprimer��5^   !   6L   5_      5a      �� 5c      $��5��6   $��1��6)   $
��Left=�69   5e      5h      5j      5k      