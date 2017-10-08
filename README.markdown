# SimpleSlack.NET
Synchronous C#.NET Slack library, designed to be as simple as possible to use. This README file aims to have a list of currently implemented API methods.

## Slack Web API
This module allows to help executing requests via Slack Web API. For reference of currently available methods, see https://api.slack.com/methods. Methods names will be also referenced in this manual.

### Groups
#### Get list of groups and send message as bot to one of them
	var client = new SlackWebApiClient("##custom_bot_token##");
	var groups = client.Groups.List();
	
	var myGroup = groups.Single(g => g.Name = "my_private_channel");
	client.Chat.PostMessage(myGroup, "This is my message");
	