export default class Resources {
	public static pageAdresses = {
		home: "/",
		lol: "/:gameType",
		lolTournaments: "/:gameType/:leagueId",
		lolTournamentScoreBoard: "/:gameType/:leagueId/:tournamentId/scoreBoard",
		lolTournamentMatchList: "/:gameType/:leagueId/:tournamentId/matches",
		lolTournamentPlayerStatsList: "/:gameType/:leagueId/:tournamentId/playerStats",
		lolMatch: "/:gameType/match/:matchId",
	};
	public static buttons = {
		accept: "Akceptuję",
	};
}
