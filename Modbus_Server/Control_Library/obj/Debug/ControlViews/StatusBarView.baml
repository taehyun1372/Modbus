   M S B A M L   `   `   `  ����J  FControl_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Control_Library.ControlViewsControl_Library.ControlViews  5      0    *Control_Library.ControlViews.StatusBarView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NAvalonDock, Version=4.72.1.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Control_Library.ControlViews     5      .��5	      ��   �� Padding$  	12 3 12 3q�6   ._�5
   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $
��Left=�6B   $��Center=�6]   .+�5      �� ��5      `� 5       �� StringFormat$ ({0} : {1})��6'   .1�5      ��  �� Path$ Address�6&   �� 5      $
 Port�6&   5      5      �� 5      $��10 0 0 0q�6   $��SemiBold"�6.   ��5      �� 5       �� 
TargetType" ��6     �� Triggers 5      �� 5   "    �� Binding 6.   �� *IsConnected+ �� Value true6N   .a�5   &   �� 	 �� Property	 � ��
 �� Value

 � � �6C   �� 5   &   	 � ��$
 Server is opened��6=   5   #   �� 5    "    6.   �� *IsConnected+	 false6N   .a�5!   &   �� 	 � ��

 �  ��6C   �� 5"   &   	 � ��$
 Server is closed��6=   5#   #   5%      5'      5(      �� 5)      $ 
Horizontal=�6   $��1��62   $��Right=�6B   $��Center=�6^   .+�5*      �� ��5+      `� 5,      $+ %Connections : {0}, Tx : {1}, Rx : {2}��6'   .1�5-      �� $ ConnectionCounts�6&   �� 5.      $ TxCounts�6&   �� 5/      $ RxCounts�6&   50      52      53      54      55      56      