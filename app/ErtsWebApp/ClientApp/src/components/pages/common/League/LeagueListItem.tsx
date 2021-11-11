import { Card, CardGroup, Col, Container, Image, Row } from "react-bootstrap";
import { useHistory } from "react-router";
import { LeagueImageDto } from "../../../../services/GeneratedClient";

function LeagueListItem(props: { gameType: string; leagueImageDto: LeagueImageDto }) {
	let history = useHistory();

	const redirectToPage = (page: string) => {
		history.push(page);
	}

	var gameType = props.gameType;
	var color = 'transparent'
	var leagueImageDto = props.leagueImageDto;
	return (

		<Card className="align-items-center" bg={color} border='white' style={{ width: '10rem', color: "white", textAlign: "center" }}
			onClick={() => redirectToPage(`${gameType}/${leagueImageDto.id}`)}

		>
			<Image src={leagueImageDto.imageUrl} rounded
				width={150}
				height={150} />

			<h6>{leagueImageDto.name}</h6>
		</Card>

	);
}

export default LeagueListItem;
