イントラネット テンプレートを使用するには、Windows 認証を有効にして、匿名認証を

詳細な手順 (IIS 6.0 の手順も含む) については、以下を参照してください。
http://go.microsoft.com/fwlink/?LinkID=213745

IIS 7
1. IIS マネージャーを開き、Web サイトに移動します。
2. [機能ビュー] の [認証] をダブルクリックします。
3. [認証] ページで、[Windows 認証] を選択します。 [認証] ページで、[Windows 認証] を選択し
   ます。Windows 認証がオプション
        Windows 認証を有効にするには:
 a) [コントロール パネル] の [プログラムと機能] を開きます。
 b) [Windows の機能の有効化または無効化] をクリックします。
 c) [インターネット インフォメーション サービス]、[World Wide Web サービス]、
4. Windows 認証を使用にするには、[操作] ウィンドウの [有効] をクリックします。
5. [認証] ページで、[匿名認証] を選択します。
6. [操作] ウィンドウで、[無効にする] をクリックして、匿名認証を無効にします。

IIS Express
1. Visual Studio でプロジェクトを右クリックし、[IIS Express を使用する] をクリックします。
2. ソリューション エクスプローラーでプロジェクトをクリックして、選択します。
3. [プロパティ] ウィンドウが開いていない場合は、開きます (F4)。
4. プロジェクトの [プロパティ] ウィンドウで、次の操作を行います。
 a) [匿名認証] を [無効] に設定する。
 b) [Windows 認証] を [有効] にします。

IIS Express は Microsoft Web Platform Installer を使用してインストールできます。
    Visual Studio の場合: http://go.microsoft.com/fwlink/?LinkID=214802
    Visual Web Developer の場合: http://go.microsoft.com/fwlink/?LinkID=214800
