   M S B A M L   `   `   `  ����D  @AgendaWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AgendaWPF.ViewsAgendaWPF.Views  5          AgendaWPF.Views.AddBroker   5      W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:AgendaWPF.Views     5        N� Title$  Ajouter un courtier��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��Ajouter un courtier��6!    
  Header#��[  6<   � 5   
   $��1��6   $��0 10 0 0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $	��100 �6#   .+�5       �� $��0��6   $��0��6!   $	��Nom��61   �� 5!      -   5        $��Lastname��5!   D   $��1��6   $��0��6#   $��0 5 0 0q�63   $�� ��6T   �� 5#      $��0��6   $��1��6!   $��10 0 0 0q�61   $��Prénom��6C   �� 5$      -   5        $��	Firstname��5$   E   $��1��6   $��1��6#   $��10 5 0 0q�63   $�� ��6V   5%      � 5'   
   $��2��6   $��0 10 0 0q�6    5(      �� 5)      $
��auto �6    �� 5*      $
��auto �6     5,      �� 5-      $	��100 �6#   .+�51      �� $��0��6   $��Email��6!   �� 52      -   5        $
��Mail��52   4   $��1��6   $��0 5 0 0q�6#   $�� ��6@   53      � 55   
   $��3��6   $��0 10 0 0q�6    56      �� 57      $
��auto �6    �� 58      $
��auto �6     5:      �� 5;      $	��100 �6#   .+�5?      �� $��0��6   $	��Tel��6!   �� 5@      -   5        $��PhoneNumber��5@   4   $��1��6   $��0 5 0 0q�6#   $�� ��6G   5A      �� 5C   
   -   5         ��Name$ 	errorForm��5C   "   $��5��6   67   �� 5E   
   $��6��6   $��0 20 0 0q�6"    �� Orientation$ 
Horizontal=�64   .+�5F      �� -   5        $��Enregistrer��5F      6+   �� 5G      -   5        $��10 0 0 0q�5G      $��Annuler��6'   69   5I      5K      5L      