export default class Resources {
	public static pageAdresses = {
		home: "/",
		csgo: "/csgo",
		lol: "/lol",
		r6: "/r6",
		lolTournaments: "/lol/:leagueId",
		lolTournamentScoreBoard: "/lol/:leagueId/:tournamentId/scoreBoard",
		lolTournamentMatchList: "/lol/:leagueId/:tournamentId/matches",
		lolTournamentPlayerStatsList: "/lol/:leagueId/:tournamentId/playerStats",
		lolMatch: "/lol/match/:matchId",
	};
	public static buttons = {
		accept: "Akceptuję",
	};
}
