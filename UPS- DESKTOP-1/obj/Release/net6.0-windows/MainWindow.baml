   M S B A M L   `   `   `  ���� I  EUPS- DESKTOP-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:UPS__DESKTOP_1.UserControlsUPS__DESKTOP_1.UserControls      UPS__DESKTOP_1.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  2uc)clr-namespace:UPS__DESKTOP_1.UserControls  -     �Name$  
mainWindow��$	��750��$
��1000�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�
������  � AllowsTransparency$
 True��.���  � ColumnDefinitions �� $	��350 ��� $��* �.+��� ���#351c15 �� Padding$ 30q� �� CornerRadius$ 	25 0 0 25��._��� $��Center=�.+��� $��/Images/UPS_logo_PNG1.png��$��0 0 0 40q�$	��160��$	��160����  �� TextAlignment$ Center=�$��SemiBold"�$��28(�$��CONNECT�����#a69fa2�� -    ��Name$ connect��   buttonBlack#��[  .��"  FontAwesome.WPF.ImageAwesome  	   Icon$	 
AngleRight=�$��25��$��25��
   
Foreground
 �#ffffff$��3 0 0 0q��� $��1��$ 20q����#FFC107$ 	0 25 25 0��._�� .+��� -   $��/Images/close.png��$��25��$��0 4 5 0q�  iconApp#��[ �� $��/Images/minimize.png��$��20��$��0 7 40 0q�#��[ � $��Center=�$��Center=�$��0 10 0 0q� �� $	��150 ��� $��* ��� $	��100 � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$
��RFID��  text#��[ �� $��1��$��
AWB NUMBER��#��[ �� $��2��$��PRODUCT DETAILS��#��[ �� $��3��$��
DIMENSIONS��#��[ �� $��4��$��SENDER��#��[ �� $��5��$��SENDER PHONE��#��[ �� $��6��$��RECEIVER��#��[ �� $��7��$��RECEIVER PHONE��#��[ �� $��8��$��ORIGIN��#��[ �� $��9��$��DESTINATION��#��[ �� -    ��Name$ txtRFID��$��1��$��0�� �� AcceptsReturn$
 True���� -   $ txtAWB��$��1��$��1���� -   $ 
txtPRODUCT��$��1��$��2��$
 True���� -   $ txtDIMENSIONS��$��1��$��3��$
 True���� -   $ 	txtSENDER��$��1��$��4���� -	   $ txtSENDERPHONE��$��1��$��5���� -
   $ txtRECEIVER��$��1��$��6���� -   $ txtRECEIVERPHONE��$��1��$��7���� -   $ 	txtORIGIN��$��1��$��8��$
 True���� -   $ txtDESTINATION��$��1��$��9��$
 True���� -   $ 
rfidButton��$��2��$��0��$��	10,9,10,9q�  
buttonMain#��[ $��40��$��Get RFID��� $��1��$��10��$��0 40 0 0q� �� $��* ��� $��* �.+��� #��[ $��0 0 10 0q�$��Cancel���� -   $��1��  buttonMainGreen#��[ $��10 0 0 0q�$��Register��