   M S B A M L   `   `   `  ����F  B25_Triggers, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:_25_Triggers_25_Triggers  5   	       _25_Triggers.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:_25_Triggers     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         MyButtonStyle �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�  &	        �� 5
   
   " ��6&    5      �� 5       6   �� *	IsRunning+ true6<   .a�5      ��  � ��$
 Stop��60   �� 5       � ��
 �\\��63   5      �� 5       6   �� *	IsRunning+	 false6<   .a�5      ��  � ��$ Resume��60   �� 5       � ��
 �����63   5      .�5      ��  � ��
 �   �6+   5      5      .��5      �� .+�5   
   �� -   5        $	��100��5      $��50��6   #��[  6>   5      �� 5   
   ��6   �� *	IsRunning+5      5      