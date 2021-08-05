import React from "react";
import Navigation from "./components/fragments/Navigation";
import Home from "./components/pages/Home";
import Footer from "./components/fragments/Footer";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Resources from "./Resources";
import R6Home from "./components/pages/r6/R6Home";
import LolLeagueList from "./components/pages/lol/LolLeagueList";
import LolTournamentList from "./components/pages/lol/LolTournamentList";
import LolTournamentScoreBoard from "./components/pages/lol/Tournament/LolTournamentScoreBoard";
import LolTournamentSeries from "./components/pages/lol/Tournament/LolTournamentSeriesList";

const App: React.FunctionComponent = () => {
	document.body.style.backgroundColor = "#778899";
	return (
		<BrowserRouter>
			<Navigation />
			<Switch>
				<Route path={Resources.pageAdresses.home} exact component={Home} />
				<Route exact path={Resources.pageAdresses.r6} component={R6Home} />
				<Route
					exact
					path={Resources.pageAdresses.lol}
					component={LolLeagueList}
				/>
				<Route exact path={Resources.pageAdresses.csgo} component={Home} />
				<Route
					exact
					path={Resources.pageAdresses.lolTournaments}
					component={LolTournamentList}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentScoreBoard}
					component={LolTournamentScoreBoard}
				/>
				<Route
					exact
					path={Resources.pageAdresses.lolTournamentSeries}
					component={LolTournamentSeries}
				/>
			</Switch>
			<Footer />
		</BrowserRouter>
	);
};

export default App;
