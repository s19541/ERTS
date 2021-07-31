import React from "react";
import { Container, Row, Col, Image, Table } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import {
	TournamentClient,
	TournamentShortDto,
} from "../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../_infrastructure/actions/SendAction";
import LolTournamentListTable from "./LolTournamentListTable";

interface IProps {}

interface IPassedProps {
	leagueId: string;
}

interface IState {
	leagueId: number;
	tournaments: TournamentShortDto[] | null;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentList extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			leagueId: Number(props.match.params.leagueId),
			tournaments: null,
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
	}

	render() {
		return (
			<Container style={{ paddingBottom: "10vh", paddingTop: "5vh" }}>
				<LolTournamentListTable tournamentList={this.state.tournaments} />
			</Container>
		);
	}
}
export default withRouter(LolTournamentList);
