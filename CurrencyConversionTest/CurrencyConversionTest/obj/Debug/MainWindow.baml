   M S B A M L   `   `   `  ����Q  MCurrencyConversionTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CurrencyConversionTestCurrencyConversionTest  5   	   '    !CurrencyConversionTest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:CurrencyConversionTest     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ Title��5
      $��Currency Converter��6   $��58��6<   $	��Top=�6H   $	��303��6`   $
��Bold"�6l   $��32(�6~   $��	10,10,0,0q�6�   �� 5   
   -   5         ��Name$ currencySelectionComboBox��5      $��230,123,422,0q�66   $	��Top=�6M   .@�5      �� $	��USD��6   �� 5      $	��AUD��6   �� 5      $	��EUR��6   5      �� 5   
   -   5        $ comboboxHeading��5      $��Select Starting Currency��6)   $��230,92,422,0q�6L   $	��Top=�6b   {�.  6z   �� 5   
   -   5         ��Name$ amountTextbox��5      $
��Left=�6)   $��23��6D   $��230,221,0,0q�6P    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��120��6�    K� ZIndex$ 3��6�   6�   �� 5   
   $��Amount��6   $��230,190,0,0q�6!   $	��Top=�66   $	��120��6N   $
��Left=�6Z   �� 5   
   -   5        $ conversionRateLabel��5      $�� ��6-   $
��Left=�68   $��410,119,0,0q�6S   $	��Top=�6h   $	��131��6�   �� 5   
   -   5        $ conversionLabel��5      $��
New Amount��6)   $
��Left=�6>   $��410,198,0,0q�6Y   $	��Top=�6n   $	��120��6�   �� 5   
   -   5        $ newAmountTextbox��5      $
��Left=�6,   $��23��6G   $��410,221,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�    �� 
IsReadOnly . 6�   5      5      