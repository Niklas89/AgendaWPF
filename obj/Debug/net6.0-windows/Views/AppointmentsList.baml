   M S B A M L   `   `   `  ����D  @AgendaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AgendaWPF.ViewsAgendaWPF.Views  5      &     AgendaWPF.Views.AppointmentsList   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:AgendaWPF.Views     5        N� Title$  AppointmentsList��5	      .��5      ]� .+�5   
   �� -   5        $��	buttonBar��5       �� Orientation$ 
Horizontal=�6&   $��Right=�6?    � LayoutTransform 5      �� 5       �� Angle$ 90Q�6"   .+�5      �� -   5        $��btnOne��5      $��0,0,5,0q�6B   $��	10,1,10,1q�6S   ��5      �� 5       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5      �  � Color$ 	#FFFFE800��6'    � Offset$ 0Q�69   � 5      $ 	#FFFCFCFC��6'   $ 0.537Q�69   5      .��5   %   Modifier Courtier5      5      � 5   
   -   5        $��
parentGrid��5      .+�5       � -   5        $��layer0��5       .+�5!      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5!         AlternatingRowBackground
 ��ح�	 �� AlternationCount$	 2��5"      
   AutoGenerateColumns$
 False��6)      Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$
 Date��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ AppointmentVm.DateHour� �� Mode$ TwoWay=�  5%      $ Sujet��6-    6>   �� $ AppointmentVm.Subject�$ TwoWay=�  5&      $ Courtier Prénom��6-    6H   �� $ BrokerVm.Firstname�$ TwoWay=�  5'      $ Courtier Nom��6-    6E   �� $ BrokerVm.Lastname�$ TwoWay=�  5(      $ Client Prénom��6-    6F   �� $ CustomerVm.Firstname�$ TwoWay=�  5)      $ 
Client Nom��6-    6C   �� $ CustomerVm.Lastname�$ TwoWay=�4  .System.Windows.Controls.DataGridTemplateColumn  5*      $
 View��61      CellTemplate 5+      �� 5,   "   .R�5-   &   �� $��btnView��6-   -   5        $
��View��5-   <   6K   5.   #   50      52      53      � 58      -   5        $��
gridlayer1��58      $y�	Collapsed=�6%    � ColumnDefinitions 59      �� 5:      �� 5;       z� SharedSizeGroup$ column1��6'   $
��auto �6A   .+�5?      � $��1��6   
����ح� � RowDefinitions 5B      �� 5C      $
��auto �6(   �� 5D      .+�5G      ]� $��0��6    .+�5H      �� -   5        $��	panel1Pin��5H   ,   $��26��6!   $��Right=�6=   
�������.��5I      �� -	   5        $��panel1PinImg��5I   $   $��/Images/HorizontalPin.jpg��68   5J      �� 5M       �� Padding$
 25,8q�6$   $��CharacterEllipsis=�63   
���   �$
��Left=�6g   
Formulaire6�   5O      �� 5Q      -
   5        $��listBoxForm��5Q   8   $��10q�6   $��1��6+   .@�5R      �� -   5        $��	errorForm��5R   %   68   �� 5S      -   5        $��txtIdAppointment��5S   .   $��23��6"   $��50��6F   $y�Hidden=�6Q    �� 
IsReadOnly$
 True��6e   �� 5T      $
��Date��6&   �� 5U      -   5        $��txtDateHour��5U   .   $��23��6"   $	��150��6A   $�� ��6M   �� 5V      $��Sujet��6&   �� 5W      -   5        $��
txtSubject��5W   .   $��23��6"   $	��150��6@   $�� ��6L   �� 5X      $��Nom du courtier��6'   �� 5Y      -   5        $��
BrokerName��5Y   ~    �� DisplayMemberPath$ Lastname��6D    �� SelectedValuePath$ IdBroker��6a   $	��150��6�    �� SelectedValue 6#   �� *Broker+6�   �� 5Z      $��Nom du client��6'   �� 5[      -   5        $��
ClientName��5[   �   $ Lastname��6F   $ 
IdCustomer��6c   $	��150��6�    6#   �� *
Customer+6�   �� 5\      -   5        $��Modifier��5\   !   6I   �� 5]      -   5        $��	Supprimer��5]   !   6L   5^      5`      �� 5b      $��5��6   $��1��6)   $
��Left=�69   5d      5g      5i      5j      