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
			key: "Leagues"
		};
	}

	componentDidMount() {
		this.getLeagueImages("");
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
				<Container style={{ paddingBottom: "10vh", paddingTop: "5vh", paddingRight: "14vh" }}>
					<GameNav activeKey={"Leagues"} gameType={this.state.gameType} onHandleEvent={(fragment) => this.getLeagueImages(fragment)} />

					<Navbar variant="dark" bg="dark">
						<Container fluid>
							<Navbar.Brand style={{ width: 800 }}>
								<Form>
									<Col md="auto">
										<Form.Control type="text" placeholder="Enter fragment of league name" onChange={(event) => this.getLeagueImages(event.target.value)} />
									</Col>
								</Form>
							</Navbar.Brand>
							<Navbar.Brand>
								<Nav activeKey={"Leagues"}>
									<NavDropdown
										id="nav-dropdown"
										title={this.state.key}
										menuVariant="dark"
									>
										<NavDropdown.Item eventKey="Leagues" active>Leagues</NavDropdown.Item>
										<NavDropdown.Item eventKey="Teams">Teams</NavDropdown.Item>
									</NavDropdown>
								</Nav>
							</Navbar.Brand>
						</Container>
					</Navbar>

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
