using UnityEngine;
using ObjPool;


namespace GunSystem
{

	public class Gun : MonoBehaviour
	{
		public float speed = 10; // скорость пули
		public Transform gunPoint; // точка рождения
		public float fireRate = 1; // скорострельность

		public Transform zRotate; // объект для вращения по оси Z

		[SerializeField] AbstractBullet currentBullet;

		// ограничение вращения
		public float minAngle = -40;
		public float maxAngle = 40;

		private GunEnergy gunEnergy;



		private float curTimeout;
		private Aim aim;
		public Transform player;
		[SerializeField] private GameObject playerGo;

		private void Awake()
		{
			gunEnergy = GetComponent<GunEnergy>();
			aim = GetComponent<Aim>();
		}

		private void SetRotation()
		{
			Vector3 mousePosMain = Input.mousePosition;
			mousePosMain.z = Camera.main.transform.position.z; //
			Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosMain);
			lookPos = lookPos - transform.position;
			float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
			angle = Mathf.Clamp(angle, minAngle, maxAngle);
			zRotate.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}

		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				Fire();
			}
			else
			{
				curTimeout = 100;
			}

			if (zRotate && aim.isAiming == false)
			{
				SetRotation();
			}
		}

		private void Fire()
		{
			curTimeout += Time.deltaTime;
			if (curTimeout > fireRate)
			{
				curTimeout = 0;

				GameObject newBullet = Instantiate(currentBullet.bulletPrefab, gunPoint.position,
					transform.rotation);

				if (!gunEnergy.isInfiniteGunEnergy)
				{
					gunEnergy.gunEnerdy--;
				}

				if (gunPoint.position.x < player.position.x)
				{
					newBullet.GetComponent<Rigidbody2D>().velocity = -transform.right * currentBullet.speed;
				}
				else if (gunPoint.position.x > player.position.x)
				{
					newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * currentBullet.speed;
				}
			}
		}


	}
}
