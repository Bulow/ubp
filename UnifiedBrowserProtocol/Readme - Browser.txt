
This is for you if your app is a browser.

	In order to let the OS know that your app can open ubp uri's, you need to include the following in your WMAppManifest.xml

		<Deployment>
		  <App>
			<Extensions>
			  <Protocol Name="ubp" NavUriFragment="ubpUrl=%s" TaskID="_default" />
			</Extensions>
		  </App>
		</Deployment>


	When a ubp link is opened in your browser, the navigation Uri recieved by you app looks like this:

		"/Protocol?ubpUrl=ubp%3Ahttp%3A%2F%2Fdomain.com"

		In order to extract the url, you must use Ubp.UbpMapper.MapUri()