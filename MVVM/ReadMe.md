# 参考
https://github.com/Fody/PropertyChanged
# 安装
```
PM> Install-Package Fody
PM> Install-Package PropertyChanged.Fody
```
# 配置
Add <PropertyChanged/> to FodyWeavers.xml
如果找不到这个文件，运行一边就可以了生成了
```
<Weavers>
  <PropertyChanged/>
</Weavers>
```
# 使用
新建一个 TestVM类
设置为public 并 继承INotifyPropertyChanged接口，自动补全PropertyChangedEventHandler事件
```
    public class TextVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string TestStr => TestBool?"asdf":"0";
        public string TestBool{get;set}
    }
```
在View类中绑定DataContext
```
    this.DataContext = new TextVM();
```
在View样式中绑定属性
```
        <StackPanel Orientation="Vertical">
            <CheckBox IsChecked="{Binding TestBool,Mode=TwoWay}" Content="TestBool"/>
            <TextBlock Text="{Binding TestStr,Mode=OneWay}"/>
        </StackPanel>
```