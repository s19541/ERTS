import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../../css/myStyle.css";
import {
	TournamentClient,
	TournamentTeamShortDto,
} from "../../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../../_infrastructure/actions/SendAction";
import TournamentNav from "../TournamentNav";
import LolTournamentTeamTable from "./TournamentTeamTable";

interface IProps { }

interface IPassedProps {
	gameType: string;
	tournamentId: string;
}

interface IState {
	gameType: string;
	tournamentId: number;
	tournamentTeams: TournamentTeamShortDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class TournamentScoreBoard extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			gameType: props.match.params.gameType,
			tournamentId: Number(props.match.params.tournamentId),
			tournamentTeams: null,
			key: "scoreboard",
		};
	}

	componentDidMount() {
		let actionParameters: IActionParameters<TournamentTeamShortDto[] | null> = {
			action: () =>
				new TournamentClient().getTournamentTeamsShort(this.state.tournamentId),
			onSuccess: (response) => {
				this.setState({
					tournamentTeams: response,
				});
			},
		};

		SendActionWithResponse(actionParameters);
	}

	render() {
		return (
			<Container
				style={{
					paddingBottom: "10vh",
					paddingTop: "5vh",
				}}
			>
				<TournamentNav activeKey={this.state.key} gameType={this.state.gameType} />
				<LolTournamentTeamTable
					tournamentTeamList={this.state.tournamentTeams}
				/>
			</Container>
		);
	}
}
export default withRouter(TournamentScoreBoard);
