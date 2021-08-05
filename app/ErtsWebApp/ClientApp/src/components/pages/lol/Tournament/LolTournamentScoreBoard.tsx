import React from "react";
import { Container } from "react-bootstrap";
import { RouteComponentProps, withRouter } from "react-router-dom";
import "../../../../css/myStyle.css";
import {
	TournamentClient,
	TournamentTeamShortDto,
} from "../../../../services/GeneratedClient";
import {
	IActionParameters,
	SendActionWithResponse,
} from "../../../../_infrastructure/actions/SendAction";
import LolTournamentNav from "./LolTournamentNav";
import LolTournamentTeamTable from "./LolTournamentTeamTable";

interface IProps {}

interface IPassedProps {
	tournamentId: string;
}

interface IState {
	tournamentId: number;
	tournamentTeams: TournamentTeamShortDto[] | null;
	key: string;
}

type IJoinedProps = IProps & RouteComponentProps<IPassedProps>;

class LolTournamentScoreBoard extends React.Component<IJoinedProps, IState> {
	constructor(props: IJoinedProps) {
		super(props);

		this.state = {
			tournamentId: Number(props.match.params.tournamentId),
			tournamentTeams: null,
			key: "score-board",
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
				<LolTournamentNav activeKey={this.state.key} />
				<LolTournamentTeamTable
					tournamentTeamList={this.state.tournamentTeams}
				/>
			</Container>
		);
	}
}
export default withRouter(LolTournamentScoreBoard);
