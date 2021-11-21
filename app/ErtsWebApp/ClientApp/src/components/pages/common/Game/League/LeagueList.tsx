import React from "react";
import { Container, Row, Col, Image, CardGroup, Form, Navbar, Nav, NavDropdown } from "react-bootstrap";
import {
	LeagueClient,
	LeagueImageDto,
} from "../../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../../_infrastructure/actions/SendAction";
import LeagueListItem from "./LeagueListItem";
import { RouteComponentProps } from "react-router-dom";
import GameNav from "../GameNav";

interface IProps { }

interface IPassedProps {
	gameType: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

interface IState {
	leagues: LeagueImageDto[] | null;
	gameType: string;
	key: string;
}

class LeagueList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			leagues: null,
			gameType: props.match.params.gameType,
			key: "leagues"
		};
	}

	componentDidMount() {
		var fragment = new URLSearchParams(this.props.location.search).get("fragment")?.toString() ?? "";
		this.getLeagueImages(fragment);
	}

	getLeagueImages(fragment: string) {
		let actionParameters: IActionParameters<LeagueImageDto[] | null> = {
			action: () => new LeagueClient().getLeagueImages(this.state.gameType, fragment.toLowerCase()),
			onSuccess: (response) => {
				this.setState({
					leagues: response
				});
			},
		};
		SendActionWithResponse(actionParameters);
	}

	render() {
		return (
			this.state.leagues && (
				<Container style={{ paddingBottom: "10vh", paddingTop: "5vh", paddingRight: "6vh", paddingLeft: "6vh" }}>
					<GameNav activeKey={"leagues"} gameType={this.state.gameType} onHandleEvent={(fragment) => this.getLeagueImages(fragment)} />

					<CardGroup>
						{this.state.leagues.map((league, i) => (
							<span style={{ padding: "2vh" }} key={league.id}>

								<LeagueListItem
									gameType={this.state.gameType}
									leagueImageDto={league}
								/>
							</span>
						))}
					</CardGroup>
				</Container>
			)
		);
	}
}
export default LeagueList;
