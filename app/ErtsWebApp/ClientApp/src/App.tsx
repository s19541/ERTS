import React from "react";
import Navigation from "./components/fragments/Navigation";
import Home from "./components/pages/Home";
import Footer from "./components/fragments/Footer";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import Resources from "./Resources";
import R6Home from "./components/pages/r6/R6Home";

const App: React.FunctionComponent = () => {
	document.body.style.backgroundColor = "#808080";
	return (
		<BrowserRouter>
			<Navigation />
			<Switch>
				<Route path={Resources.pageAdresses.home} exact component={Home} />
				<Route path={Resources.pageAdresses.r6} component={R6Home} />

				<Redirect exact to={"/"} />
			</Switch>
			<Footer />
		</BrowserRouter>
	);
};

export default App;
