
This is for you if your app is a normal app that needs to launch webpages.


	In order to open a url in the "default" browser, use:

	Microsoft.Phone.Tasks.AnyBrowserTask.Show(string url);

	or

	Microsoft.Phone.Tasks.AnyBrowserTask.Show(Uri uri);

	or

	Microsoft.Phone.Tasks.AnyBrowserTask task = new Microsoft.Phone.Tasks.AnyBrowserTask(url);
	task.Show();

	or

	Microsoft.Phone.Tasks.AnyBrowserTask task = new Microsoft.Phone.Tasks.AnyBrowserTask(uri);
	task.Show();