using CandidateTesting.PatrickHiannKonasugawa.Frontend;

while( true )
{
	Console.Clear();
	Console.WriteLine( "Do you want to do?" );
	Console.WriteLine( "1 - Type a custom command" );
	Console.WriteLine( "2 - See a mock test;" );
	Console.WriteLine( "0 - Close this application;" );
	Console.Write( "Your choice: " );

	ConsoleKeyInfo key = Console.ReadKey();

	switch( key.KeyChar )
	{
		case '0':
			return;
		case '1':
			new MainApp();
			break;
		case '2':
			new MockApp();
			break;
		default:
			Console.Clear();
			Console.WriteLine( "Invalid choice! Press any key to continue..." );
			Console.ReadKey();
			break;
	}
}
