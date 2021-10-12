import React from "react";
import { Container, Row, Col, Image, Table } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import {
	LeagueClient,
	LeagueDto,
	TournamentClient,
	TournamentShortDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import LolTournamentListTable from "./TournamentListTable";

interface IProps { }

interface IPassedProps {
	leagueId: string;
}

interface IState {
	leagueId: number;
	tournaments: TournamentShortDto[] | null;
	league: LeagueDto | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class TournamentList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			leagueId: Number(props.match.params.leagueId),
			tournaments: null,
			league: null,
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<TournamentShortDto[] | null> = {
			action: () =>
				new TournamentClient().getTournamentsShort(this.state.leagueId),
			onSuccess: (response) => {
				this.setState({
					tournaments: response,
				});
			},
		};

		SendActionWithResponse(actionParameters);

		let actionParameters2: IActionParameters<LeagueDto | null> = {
			action: () => new LeagueClient().get(this.state.leagueId),
			onSuccess: (response) => {
				this.setState({
					league: response,
				});
			},
		};

		SendActionWithResponse(actionParameters2);
	}

	render() {
		return (
			<Container style={{ paddingBottom: "10vh", paddingTop: "5vh" }}>
				<Row className="align-items-center">
					<Col md="auto">
						<Image src={this.state.league?.imageUrl} rounded />
					</Col>
					<Col md="auto">
						<p className="h1 text-white">{this.state.league?.name}</p>
						<p>
							<a href={this.state.league?.url} className="h3 text-white">
								{this.state.league?.url}
							</a>
						</p>
					</Col>
				</Row>
				<LolTournamentListTable
					tournamentList={this.state.tournaments}
					leagueId={this.state.leagueId}
				/>
			</Container>
		);
	}
}
export default withRouter(TournamentList);
