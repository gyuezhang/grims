# 库
MapsUI
# 参考
https://mapsui.com/documentation/getting-started-wpf.html
# 安装
Install-Package Mapsui
# 使用
In WpfApplication1.MainWindow.xaml add this in the Grid element:
```
<xaml:MapControl Name="MyMapControl"></xaml:MapControl>
```
And add the namespace: 
```
xmlns:xaml="clr-namespace:Mapsui.UI.Wpf;assembly=Mapsui.UI.Wpf"
```
In WpfApplication1.MainWindow.xaml.cs add in the constructor:
```
MyMapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));
```
And add the namespaces: 
```
using BruTile.Predefined; 
using Mapsui.Layers;
```