   M S B A M L   `   `   `  ����D  @AgendaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AgendaWPF.ViewsAgendaWPF.Views  5      $    AgendaWPF.Views.AddAppointment   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:AgendaWPF.Views     5        N� Title$  Ajout de rendez-vous��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Ajouter un rendez-vous��6!    
  Header#��[  6?   � 5   
   $��1��6   $��0 10 0 0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $	��100 �6#   .+�5!      �� $��0��6   $��0��6!   $��	Courtiers��61   �� 5"      -   5        $��
BrokerName��5"   �   $��1��6   $��0��6F   $��0 5 0 0q�6V    �� DisplayMemberPath$ Lastname��6g    �� SelectedValuePath$ IdBroker��6�    �� SelectedValue 6$   �� *Broker+6�   �� 5$      $��0��6   $��1��6!   $��10 0 0 0q�61   $��Clients��6C   �� 5%      -   5        $��
ClientName��5%   �   $��1��6   $��1��6G   $��10 5 0 0q�6W   $ Lastname��6i   $ 
IdCustomer��6�    6$   �� *
Customer+6�   5&      � 5(   
   $��2��6   $��0 10 0 0q�6    5)      �� 5*      $
��auto �6    �� 5+      $
��auto �6     5-      �� 5.      $	��100 �6#   �� 5/      $	��100 �6#   .+�53      �� $��0��6   $��2��6!   $��Date du rendez-vous��65   (  "System.Windows.Controls.DatePicker  54      -   5        $��AppointmentDate��54   K   $��1��6   $��2��6&   $��0 5 0 0q�6:      SelectedDateFormat$
 Long=�6b   55      � 57   
   $��3��6   $��0 10 0 0q�6    58      �� 59      $
��auto �6    �� 5:      $
��auto �6     5<      �� 5=      $	��100 �6#   �� 5>      $	��100 �6#   .+�5B      �� $��0��6   $��0��6!   $��Heure��61   �� 5C      -   5        $��AppointmentHour��5C   D   $��1��6   $��0��6#   $��0 5 0 0q�63   $�� ��6[   �� 5E      $��0��6   $��1��6!   $��Minutes��61   �� 5F      -   5        $��AppointmentMinute��5F   E   $��1��6   $��1��6#   $��10 5 0 0q�63   $�� ��6^   5G      � 5I   
   $��4��6   $��0 10 0 0q�6    5J      �� 5K      $
��auto �6    �� 5L      $
��auto �6     5N      �� 5O      $	��100 �6#   �� 5P      $	��100 �6#   .+�5T      �� $��0��6   $��2��6!   $��Sujet du rdv��66   �� 5U      -   5        $��AppointmentSubject��5U   H   $��1��6   $��2��6#   $��0 5 0 0q�67   $�� ��6b   5W      �� 5Y   
   -   5         ��Name$ 	errorForm��5Y   "   $��5��6   67   �� 5[   
   $��6��6   $��0 20 0 0q�6"    �� Orientation$ 
Horizontal=�64   .+�5\      �� -   5        $��Enregistrer��5\      6+   �� 5]      -	   5        $��10 0 0 0q�5]      $��Annuler��6'   69   5_      5a      5b      