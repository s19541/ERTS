import React from "react";
import Heading from "./components/fragments/Heading";
import Home from "./components/pages/Home";
import Footer from "./components/fragments/Footer";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Resources from "./Resources";
import LeagueList from "./components/pages/common/Game/League/LeagueList";
import TeamList from "./components/pages/common/Game/Team/TeamList";
import TournamentList from "./components/pages/common/Tournament/TournamentList";
import SerieList from "./components/pages/common/Serie/SerieList";
import LolTournamentScoreBoard from "./components/pages/common/Tournament/Teams/TournamentScoreBoard";
import TournamentMatchList from "./components/pages/common/Tournament/Matches/TournamentMatchList";
import LolTournamentPlayerStatsList from "./components/pages/lol/Tournament/LolTournamentPlayerStatsList";
import LolTournamentTeamStatsList from "./components/pages/lol/Tournament/LolTournamentTeamStatsList";
import MatchStats from "./components/pages/lol/Match/MatchStats";
import GameStats from "./components/pages/lol/Game/GameStats";
import TeamStats from "./components/pages/common/Team/TeamStats";

const App: React.FunctionComponent = () => {
	document.body.style.backgroundColor = "#778899";
	return (
		<BrowserRouter>
			<Heading />
			<Switch>
				<Route path={Resources.pageAdresses.home} exact component={Home} />
				<Route
					exact
					path={Resources.pageAdresses.team}
					component={TeamStats}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolMatch}
					component={MatchStats}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolGame}
					component={GameStats}
				/>
				<Route
					exact
					path={Resources.pageAdresses.gameLeagues}
					render={(props) => <LeagueList {...props} ref={r => r?.onGameChanged()} />}
				/>
				<Route
					exact
					path={Resources.pageAdresses.gameTeams}
					component={TeamList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.series}
					component={SerieList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.tournaments}
					component={TournamentList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentScoreBoard}
					component={LolTournamentScoreBoard}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentMatchList}
					component={TournamentMatchList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentPlayerStatsList}
					component={LolTournamentPlayerStatsList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentTeamStatsList}
					component={LolTournamentTeamStatsList}
				/>
			</Switch>
			<Footer />
		</BrowserRouter>
	);
};

export default App;
