   M S B A M L   `   `   `  ����J  FControl_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Control_Library.PopupViewsControl_Library.PopupViews  5   	   5    /Control_Library.PopupViews.CommunicationLogView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NAvalonDock, Version=4.72.1.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Control_Library.PopupViews     5   	     � Title$  Communication Log��5   	   $	��370��6#   $	��640��60    � 	Resources 5	         ResumeButtonStyle �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�  &	        �� 5
   
   " ��6*    5      �� 5       6   �� *	IsRunning+ true6<   .a�5      ��  � ��$
 Stop��60   �� 5       � ��
 �\\��63   5      �� 5       6   �� *	IsRunning+	 false6<   .a�5      ��  � ��$ Resume��60   �� 5       � ��
 ��ح�63   5      .�5      ��  � ��
 �   �6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� 	 �� Orientation$	 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   .+�5      �� -   5        $��	btnResume��5      #��[  6&   $��12(�6Q   $��25��6_   $��50��6k   $��10 0 5 3q�6v   6�   �� 5       -   5        $��btnClear��5       $��Clear��6%   $��25��65   $��50��6A   $��5 0 5 3q�6L   6]   �� 5!      -   5        $��btnSave��5!      $
��Save��6$   $��25��63   $��50��6?   $��5 0 10 3q�6J   6\   �� 5"      -   5        $��cbDate��5"      $��12(�6%   $
��Date��63   $��Center=�6_   $��40 0 5 0q�6�   
 d� 	IsChecked
 6B   �� *IsDate+6�   �� 5#      -   5        $��cbTime��5#      $��12(�6%   $
��Time��63   $��Center=�6_   $��5 0 10 0q�6�   
 6B   �� *IsTime+6�   �� 5$      $��Message Format��6   $��20 0 0 0q�6/   .��5%      �� $	 
Horizontal=�6   .+�5&      	� $
��Byte��6"   $��12(�61   $��Bottom=�6c   $��40 0 5 0q�6�   
 6?   �� *IsByteMessage+6�   	� 5'      $
��Text��6"   $��12(�61   $��Bottom=�6c   $��5 0 0 0q�6�   
 6?   �� *IsTextMessage+6�   5(      5)      5*      �� 5+   
   $��Communication Log��6   $��1��6.   .��5,      �� -   5        $��lvCommunicationLog��5,   "   $��5q�6    �� SelectionMode$ Multiple=�6g   ��6<   �� *OriginalPacketLogs+ �� View 5-      �� 5.      -   5        
myGridView��5/      51      52      53      54      