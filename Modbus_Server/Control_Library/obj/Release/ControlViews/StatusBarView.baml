   M S B A M L   `   `   `  ���� J  FControl_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Control_Library.ControlViewsControl_Library.ControlViews  0    *Control_Library.ControlViews.StatusBarView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NAvalonDock, Version=4.72.1.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Control_Library.ControlViews     .����   �� Padding$  	12 3 12 3q�._��  � ColumnDefinitions �� �� .+���  �� Orientation$ 
Horizontal=�$��0��$
��Left=�$��Center=�.+��� ��`�  �� StringFormat$ ({0} : {1})��.1���  �� Path$ Address��� $
 Port��� $��10 0 0 0q�$��SemiBold"�����  �� 
TargetType" �� �� Triggers ��  �� Binding �� *IsConnected+ �� Value true.a��� 	 �� Property	 � ��
 �� Value

 � � ��� 	 � ��$
 Server is opened����  �� *IsConnected+	 false.a��� 	 � ��

 �  ���� 	 � ��$
 Server is closed���� $ 
Horizontal=�$��1��$��Right=�$��Center=�.+��� ��`� $+ %Connections : {0}, Tx : {1}, Rx : {2}��.1��� $ ConnectionCounts��� $ TxCounts��� $ RxCounts�