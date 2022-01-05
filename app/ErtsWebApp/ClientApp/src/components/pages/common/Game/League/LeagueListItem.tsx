import { Card, Image } from "react-bootstrap";
import { useHistory } from "react-router";
import { LeagueImageDto } from "../../../../../services/GeneratedClient";

interface IProps {
	gameType: string;
	leagueImageDto: LeagueImageDto;
}

const LeagueListItem: React.FunctionComponent<IProps> = (props) => {
	let history = useHistory();

	const redirectToPage = (page: string) => {
		history.push(page);
	}

	var gameType = props.gameType;
	var leagueImageDto = props.leagueImageDto;
	return (

		<Card className="align-items-center" bg={'transparent'} border='white' style={{ width: '10rem', color: "white", textAlign: "center" }}
			onClick={() => redirectToPage(`/${gameType}/${leagueImageDto.id}`)}
		>
			<Image src={leagueImageDto.imageUrl} rounded
				width={150}
				height={150} />

			<h6>{leagueImageDto.name}</h6>
		</Card>

	);
}

export default LeagueListItem;
