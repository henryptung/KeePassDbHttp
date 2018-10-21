# KeePassDbHttp

This plugin integrates KeePass with the KeePass Tusk browser extension by exposing a `localhost` HTTP endpoint.

## Usage notes

- KeePass Tusk loads the raw database file rather than integrating directly with KeePass.
  Changes will not be visible to the browser until after the database is saved.

## Installation instructions

1. Download and install [KeePass 2.x](https://keepass.info/download.html) if not already installed.
2. Download KeePassDbHttp.plgx and move it to the **Plugins** directory in the KeePass installation.
3. Restart KeePass.

## Integrating with KeePass Tusk

1. Open KeePass and unlock your database.
2. Under the **Tools** menu, click **KeePassDbHttp Options...** and copy the URL shown.
3. Install [KeePass Tusk](https://subdavis.com/Tusk/) in the browser of choice (if not already installed).
4. After installation, the KeePass Tusk logo should appear in your browser.
   Click it to open KeePass Tusk and choose **Add a KeePass database file**.
5. Click **Cloud Storage Setup** and enable **Shared Link**.
6. Paste the copied URL as the **Shared Link URL** and give the database a name.
7. Click **Add URL** to register the database in KeePass Tusk
8. To test the integration, open KeePass Tusk, choose the database you added and enter your master password to unlock.
