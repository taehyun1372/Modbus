   M S B A M L   `   `   `  ���� J  FControl_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Control_Library.PopupViewsControl_Library.PopupViews  5    /Control_Library.PopupViews.CommunicationLogView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NAvalonDock, Version=4.72.1.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:Control_Library.PopupViews       � Title$  Communication Log��$	��370��$	��640�� � 	Resources    ResumeButtonStyle �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value��%�   &	        �� " �� ��  �� *	IsRunning+ true.a���  � ��$
 Stop����  � ��
 �\\����  �� *	IsRunning+	 false.a���  � ��$ Resume����  � ��
 ��ح�.���  � ��
 �   �.���  � RowDefinitions �� $��40 ��� $��* �.+��� 	 �� Orientation$	 
Horizontal=�$
��Left=�$��Bottom=�.+��� -   $��	btnResume��#��[  $��12(�$��25��$��50��$��10 0 5 3q��� -   $��btnClear��$��Clear��$��25��$��50��$��5 0 5 3q��� -   $��btnSave��$
��Save��$��25��$��50��$��5 0 10 3q��� -   $��cbDate��$��12(�$
��Date��$��Center=�$��40 0 5 0q�
 d� 	IsChecked
 �� *IsDate+�� -   $��cbTime��$��12(�$
��Time��$��Center=�$��5 0 10 0q�
 �� *IsTime+�� $��Message Format��$��20 0 0 0q�.���� $	 
Horizontal=�.+�	� $
��Byte��$��12(�$��Bottom=�$��40 0 5 0q�
 �� *IsByteMessage+	� $
��Text��$��12(�$��Bottom=�$��5 0 0 0q�
 �� *IsTextMessage+�� $��Communication Log��$��1��.���� -   $��lvCommunicationLog��$��5q� �� SelectionMode$ Multiple=����� *OriginalPacketLogs+ �� View �� -   
myGridView��